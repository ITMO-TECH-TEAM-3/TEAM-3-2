using WebApplication1.enums;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class StatisticsService
{
    private readonly DatabaseContext _context;

    public StatisticsService(DatabaseContext context)
    {
        _context = context;
    }

    public ClientStatisticsInfo? GetClientStatistics(Guid clientId)
    {
        uint betsCount = 0;
        uint wonCount = 0;
        uint loseCount = 0;
        uint totalSumWon = 0;
        uint totalBetsSum = 0;
        foreach (var bet in _context.MatchBets)
        {
            if (bet.ClientId != clientId) continue;
            betsCount++;
            totalBetsSum += bet.Sum;
            if (bet.Result == BetResult.Lose)
                loseCount++;
            if (bet.Result != BetResult.Win) continue;
            wonCount++;
            totalSumWon = Enumerable.Aggregate(_context.Events.Where(evt => evt.EventId == bet.EventId), totalSumWon,
                (current, evt) => (uint) (current + bet.Sum * evt.Coefficient));
        }

        if (betsCount == 0)
            return null;
        var stat = new ClientStatisticsInfo(clientId, wonCount, loseCount, totalBetsSum, totalSumWon);
        return stat;
    }

    public TeamStatisticsInfo? GetTeamStatistics(Guid teamId)
    {
        foreach (var evt in _context.Events)
        {
            
        }
        return null;
    }
}