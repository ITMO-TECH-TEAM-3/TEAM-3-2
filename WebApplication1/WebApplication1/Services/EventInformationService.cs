using WebApplication1.Models;

namespace WebApplication1.Services;

public class EventInformationService
{
    private readonly DatabaseContext _context;

    public EventInformationService(DatabaseContext context)
    {
        _context = context;
        _context.Events!.Add(new EventInfo(Guid.NewGuid(), Guid.NewGuid(), 3.22, Guid.NewGuid()));
        _context.SaveChanges();
    }
    public IEnumerable<EventInfo>? GetEventInfo(Guid eventId)
    {
        return _context.Events?.Where(evt => evt.EventId == eventId);
    }
    public IEnumerable<BetMatch>? GetListOfMatchBets(Guid clientId)
    {
        return _context.MatchBets?.Where(bet => bet.ClientId == clientId);
    }

    public IEnumerable<BetTournament>? GetListOfTournamentBets(Guid clientId)
    {
        return _context.TournamentsBets?.Where(bet => bet.ClientId == clientId);
    }
}