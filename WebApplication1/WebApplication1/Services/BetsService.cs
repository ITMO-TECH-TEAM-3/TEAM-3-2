using WebApplication1.Enums;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class BetsService
{
    private readonly DatabaseContext _context;
    private readonly UserService _userService;
    private readonly TournamentService _tournamentService;

    public BetsService(DatabaseContext context, UserService userService, TournamentService tournamentService, TournamentService tournamentService1)
    {
        _context = context;
        _userService = userService;
        _tournamentService = tournamentService;
    }

    public BetMatch? CreateBetOnMatch(Guid clientId, uint sum, Guid eventId, Guid teamId)
    {
        var events = _context.Events!.Where(evt => evt.EventId == eventId).ToList();
        var teams = _tournamentService.TeamListInMatch(eventId);
        var players = new List<Guid>();

        if (teams.Count != 2) return null;
        
        foreach (var teamPlayers in teams.Select(team => _userService.UserListInTeam(team)))
        {
            if (teamPlayers.Count == 0)
                return null;
            players.AddRange(teamPlayers);
        }
        if (players.Contains(clientId)) return null;
        if (!events.Any())
        {
            _context.Events?.Add(new EventInfo(Guid.NewGuid(), eventId, NewCoefficient(sum, sum), teamId,
                EventResult.NotStarted, sum));
        }
        if (events.First().Result != EventResult.NotStarted) return null;
        
        UpdateEventsInfo(events, teamId, sum);
        
        var bet = new BetMatch(Guid.NewGuid(), clientId, eventId, sum, teamId, BetResult.InProgress);
        _context.MatchBets!.Add(bet);
        _context.SaveChanges();
        return bet;
    }

    public BetTournament? CreateBetOnTournament(Guid clientId, uint sum, Guid eventId, Guid teamId)
    {
        var teams = _tournamentService.TeamListInMatch(eventId);
        if (teams.Count == 0)
            return null;
        var players = new List<Guid>();
        foreach (var teamPlayers in teams.Select(team => _userService.UserListInTeam(team)))
        {
            if (teamPlayers.Count == 0)
                return null;
            players.AddRange(teamPlayers);
        }
        if (players.Contains(clientId))
            return null;
        var events = _context.Events!.Where(evt => evt.EventId == eventId).ToList();
        if (!events.Any())
        {
            _context.Events?.Add(new EventInfo(Guid.NewGuid(), eventId, NewCoefficient(sum, sum), teamId,
                EventResult.NotStarted, sum));
        }
        if (events.First().Result != EventResult.NotStarted)
            return null;
        
        UpdateEventsInfo(events, teamId, sum);
        var bet = new BetTournament(Guid.NewGuid(), clientId, eventId, sum, teamId, BetResult.InProgress);

        _context.TournamentsBets!.Add(bet);
        _context.SaveChanges();
        return bet;
    }

    private static double NewCoefficient(uint bettedSum, uint allBetsSum)
    {
        if (bettedSum == 0)
            return 0;
        return (double) allBetsSum / bettedSum;
    }

    private void UpdateEventsInfo(List<EventInfo> events, Guid teamId, uint sum)
    {
        var allBetsSum = events.Aggregate(sum, (current, evt) => current + evt.TotalSum);
        foreach (var evt in events)
        {
            _context.Events!.Remove(evt);
            _context.Events.Add(evt.TeamId == teamId
                ? new EventInfo(evt.Id, evt.EventId, NewCoefficient(evt.TotalSum + sum, allBetsSum), evt.TeamId,
                    evt.Result,
                    evt.TotalSum + sum)
                : new EventInfo(evt.Id, evt.EventId, NewCoefficient(evt.TotalSum, allBetsSum), evt.TeamId, evt.Result,
                    evt.TotalSum));
        }
    }
}