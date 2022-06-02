using System.Data.Common;
using Newtonsoft.Json;
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
        var contextTournamentsBet = _context.TournamentsBets?.FirstOrDefault(bet => bet.Id == eventId);
        if (contextTournamentsBet == null) return;

        var url = $"{_tournamentServerUrl}/{contextTournamentsBet.EventId}";
        var httpClient = new HttpClient();
        var response = httpClient.GetAsync(url).Result;
        var stringResult = response.Content.ReadAsStringAsync().Result;
        var tournamentInfo = JsonConvert.DeserializeObject<TournamentInfo>(stringResult);

        if (tournamentInfo == null) return;
        if (contextTournamentsBet.Result == tournamentInfo.TournamentStatus) return;

        _context.TournamentsBets?.Remove(contextTournamentsBet);
        _context.TournamentsBets?.Add(new BetTournament(contextTournamentsBet.Id,
            contextTournamentsBet.ClientId,
            contextTournamentsBet.EventId,
            contextTournamentsBet.Sum,
            contextTournamentsBet.TeamId,
            contextTournamentsBet.Place,
            tournamentInfo.TournamentStatus));

        _context.SaveChanges();
    }
}