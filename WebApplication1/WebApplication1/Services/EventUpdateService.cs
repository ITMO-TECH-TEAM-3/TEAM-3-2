using System.Data.Common;
using Newtonsoft.Json;
using WebApplication1.Enums;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class EventUpdateService
{
    private readonly DatabaseContext _context;
    private readonly string _tournamentServerUrl;

    public EventUpdateService(DatabaseContext context, string tournamentServerUrl)
    {
        _context = context;
        _tournamentServerUrl = tournamentServerUrl;
    }

    // может работать пока что только с турнирами, потому что на сервере турниров можно спрашивать только про турниры
    public void UpdateEventBase(Guid eventId)
    {
        var contextTournamentsBet = _context.TournamentsBets?.Where(bet => bet.Id == eventId).ToList();
        var eventInfos = _context.Events?.Where(info => info.EventId == eventId).ToList();
        var matches = _context.MatchBets?.Where(match => match.EventId == eventId).ToList();

        if (eventInfos == null) return;
        if (contextTournamentsBet == null) return;

        var matchResult = GetMatchResult(eventId);
        var tournamentInfo = GetTournamentInfo(eventId);

        if (tournamentInfo == null) return;

        foreach (var betTournament in contextTournamentsBet)
        {
            _context.TournamentsBets?.Remove(betTournament);
            _context.TournamentsBets?.Add(new BetTournament(betTournament.Id,
                betTournament.ClientId,
                betTournament.EventId,
                betTournament.Sum,
                betTournament.TeamId,
                betTournament.Place,
                tournamentInfo.TournamentStatus));
        }
        
        foreach (var eventInfo in eventInfos)
        {
            _context.Events?.Remove(eventInfo);
            _context.Events?.Add(new EventInfo(eventInfo.Id,
                eventInfo.EventId,
                eventInfo.Coefficient,
                eventInfo.TeamId,
                tournamentInfo.TournamentStatus.ToEventResult()));
        }
        
        if (matches != null)
            foreach (var betMatch in matches)
            {
                if (matchResult is not { IsDraw: false }) continue;
                
                var result = BetResult.Lose;
                
                if (matchResult.WinnerTeamId == betMatch.TeamId)
                    result = BetResult.Win;

                _context.MatchBets?.Remove(betMatch);
                _context.MatchBets?.Add(new BetMatch(betMatch.Id,
                    betMatch.ClientId,
                    betMatch.EventId,
                    betMatch.Sum,
                    betMatch.TeamId,
                    result));
            }

        _context.SaveChanges();
    }

    private MatchResult? GetMatchResult(Guid eventId)
    {
        var httpClient = new HttpClient();
        var url = $"{_tournamentServerUrl}/match/by-match/{eventId}";
        var response = httpClient.GetAsync(url).Result;
        var stringResult = response.Content.ReadAsStringAsync().Result;
        
        return JsonConvert.DeserializeObject<MatchResult>(stringResult);
    }

    private TournamentInfo? GetTournamentInfo(Guid eventId)
    {
        var url = $"{_tournamentServerUrl}/tournament/{eventId}";
        var httpClient = new HttpClient();
        var response = httpClient.GetAsync(url).Result;
        var stringResult = response.Content.ReadAsStringAsync().Result;
        
        return JsonConvert.DeserializeObject<TournamentInfo>(stringResult);
    }
}