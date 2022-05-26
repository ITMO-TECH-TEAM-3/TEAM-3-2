using WebApplication1.Models;

namespace WebApplication1.Services;

public class BetsService
{
    private readonly DatabaseContext _context;

    public BetsService(DatabaseContext context) {
        _context = context;
    }
    public async Task<BetMatch> CreateBetOnMatch(Guid clientId, uint sum, Guid eventId, Guid teamId)
    {
        //TODO: проверка на ставку на себя
        var bet = new BetMatch(Guid.NewGuid(), clientId,  eventId, sum, teamId);
        await _context.MatchBets!.AddAsync(bet);
        await _context.SaveChangesAsync();
        return bet;
    }
    
    public async Task<BetTournament> CreateBetOnTournament(Guid clientId, uint sum, Guid eventId, Guid teamId, uint place)
    {
        //TODO: проверка на ставку на себя
        var bet = new BetTournament(Guid.NewGuid(), clientId,  eventId, sum, teamId, place);
        await _context.TournamentsBets!.AddAsync(bet);
        await _context.SaveChangesAsync();
        return bet;
    }
}