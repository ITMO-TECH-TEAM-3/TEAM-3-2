using WebApplication1.Models;

namespace WebApplication1.Services;

public class BetsService
{
    private readonly DatabaseContext _context;

    public BetsService(DatabaseContext context) {
        _context = context;
    }
    public BetMatch? CreateBetOnMatch(Guid clientId, uint sum, Guid eventId, Guid teamId)
    {
        var evt = _context.Events!.ToList().FirstOrDefault(evt => evt.EventId == eventId && evt.TeamId == teamId);
        if (evt == null)
            return null;
        //TODO: проверка на ставку на себя
        var bet = new BetMatch(Guid.NewGuid(), clientId,  eventId, sum, teamId);
        _context.Events!.Remove(evt);
        _context.Events.Add(new EventInfo(evt.Id, evt.EventId, NewCoefficient(evt, sum), evt.TeamId, evt.Result,
            evt.TotalSum + sum));
        _context.MatchBets!.Add(bet);
        _context.SaveChanges();
        return bet;
    }
    
    public BetTournament? CreateBetOnTournament(Guid clientId, uint sum, Guid eventId, Guid teamId, uint place)
    {
        var evt = _context.Events!.ToList().FirstOrDefault(evt => evt.EventId == eventId && evt.TeamId == teamId);
        if (evt == null)
            return null;
        //TODO: проверка на ставку на себя
        var bet = new BetTournament(Guid.NewGuid(), clientId,  eventId, sum, teamId, place);
        _context.Events!.Remove(evt);
        _context.Events.Add(new EventInfo(evt.Id, evt.EventId, NewCoefficient(evt, sum), evt.TeamId, evt.Result,
            evt.TotalSum + sum));
        _context.TournamentsBets!.Add(bet);
        _context.SaveChanges();
        return bet;
    }
    
    private double NewCoefficient(EventInfo evt, uint sum)
    {
        //TODO: реализовать пересчет коэффициентов
        return default;
    }
}