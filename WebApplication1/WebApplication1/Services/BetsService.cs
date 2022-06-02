using WebApplication1.Enums;
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
        //TODO: проверка на ставку на себя
        var bet = new BetMatch(Guid.NewGuid(), clientId,  eventId, sum, teamId);
        _context.MatchBets!.Add(bet);
        _context.SaveChanges();
        return bet;
    }
    
    public BetTournament? CreateBetOnTournament(Guid clientId, uint sum, Guid eventId, Guid teamId, uint place)
    {
        //TODO: проверка на ставку на себя
        var bet = new BetTournament(Guid.NewGuid(), clientId,  eventId, sum, teamId, place, BetResult.InProgress);
        _context.TournamentsBets!.Add(bet);
        _context.SaveChanges();
        return bet;
    }
}