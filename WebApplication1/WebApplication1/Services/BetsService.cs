using WebApplication1.Enums;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class BetsService
{
    private readonly DatabaseContext _context;

    public BetsService(DatabaseContext context)
    {
        _context = context;
        // в качестве теста добавляю event
        var a = Guid.NewGuid();
        _context.Events?.Add(new EventInfo(Guid.NewGuid(), a, 0, Guid.NewGuid(), EventResult.NotStarted, 0));
        _context.Events?.Add(new EventInfo(Guid.NewGuid(), a, 0, Guid.NewGuid(), EventResult.NotStarted, 0));
        _context.SaveChanges();
    }

    public BetMatch? CreateBetOnMatch(Guid clientId, uint sum, Guid eventId, Guid teamId)
    {
        var events = _context.Events!.Where(evt => evt.EventId == eventId && evt.TeamId == teamId).ToList();
        if (!events.Any())
            return null;
        //TODO: проверка на ставку на себя
        UpdateEventsInfo(events, teamId, sum);
        var bet = new BetMatch(Guid.NewGuid(), clientId, eventId, sum, teamId);
        _context.MatchBets!.Add(bet);
        _context.SaveChanges();
        return bet;
    }

    public BetTournament? CreateBetOnTournament(Guid clientId, uint sum, Guid eventId, Guid teamId, uint place)
    {
        var events = _context.Events!.Where(evt => evt.EventId == eventId && evt.TeamId == teamId).ToList();
        if (!events.Any())
            return null;
        //TODO: проверка на ставку на себя
        UpdateEventsInfo(events, teamId, sum);
        var bet = new BetTournament(Guid.NewGuid(), clientId, eventId, sum, teamId, place);
        _context.TournamentsBets!.Add(bet);
        _context.SaveChanges();
        return bet;
    }

    private double NewCoefficient(EventInfo evt, int sum)
    {
        //TODO: реализовать пересчет коэффициентов
        return default;
    }

    private void UpdateEventsInfo(List<EventInfo> events, Guid teamId, uint sum)
    {
        var betSum = events.Aggregate(0, (current, evt) => (int) (current + evt.TotalSum));
        foreach (var evt in events)
        {
            _context.Events!.Remove(evt);
            _context.Events.Add(evt.TeamId == teamId
                ? new EventInfo(evt.Id, evt.EventId, NewCoefficient(evt, betSum), evt.TeamId, evt.Result,
                    evt.TotalSum + sum)
                : new EventInfo(evt.Id, evt.EventId, NewCoefficient(evt, betSum), evt.TeamId, evt.Result,
                    evt.TotalSum));
        }
    }
}