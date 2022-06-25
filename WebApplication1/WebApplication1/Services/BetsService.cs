using WebApplication1.Enums;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class BetsService
{
    private readonly DatabaseContext _context;

    public BetsService(DatabaseContext context)
    {
        _context = context;
    }

    public BetMatch? CreateBetOnMatch(Guid clientId, uint sum, Guid eventId, Guid teamId)
    {
        var events = _context.Events!.Where(evt => evt.EventId == eventId).ToList();
        if (!events.Any())
            return null;
        if (events.First().Result != EventResult.NotStarted)
            return null;
        //TODO: проверка на ставку на себя
        UpdateEventsInfo(events, teamId, sum);
        var bet = new BetMatch(Guid.NewGuid(), clientId, eventId, sum, teamId, BetResult.InProgress);
        _context.MatchBets!.Add(bet);
        _context.SaveChanges();
        return bet;
    }

    public BetTournament? CreateBetOnTournament(Guid clientId, uint sum, Guid eventId, Guid teamId)
    {
        var events = _context.Events!.Where(evt => evt.EventId == eventId).ToList();
        if (!events.Any())
            return null;
        if (events.First().Result != EventResult.NotStarted)
            return null;
        //TODO: проверка на ставку на себя
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