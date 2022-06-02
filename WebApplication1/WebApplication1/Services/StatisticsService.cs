using WebApplication1.Enums;
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

        if (_context.Events == null || _context.MatchBets == null || _context.TournamentsBets == null)
            return null;
        CountStatistics(_context.MatchBets.ToList(), clientId, ref betsCount, ref wonCount, ref loseCount,
            ref totalSumWon, ref totalBetsSum);
        CountStatistics(_context.TournamentsBets.ToList(), clientId, ref betsCount, ref wonCount, ref loseCount,
            ref totalSumWon, ref totalBetsSum);

        if (betsCount == 0)
            return null;
        var stat = new ClientStatisticsInfo(clientId, wonCount, loseCount, totalBetsSum, totalSumWon);
        return stat;
    }

    public TeamStatisticsInfo? GetTeamStatistics(Guid teamId)
    {
        uint totalWon = 0;
        if (_context.Events == null || _context.MatchBets == null || _context.TournamentsBets == null)
            return null;
        foreach (var evt in _context.Events.ToList().Where(evt => evt.TeamId == teamId && evt.Result == EventResult.Win))
        {
            totalWon++;
        }

        var totalSum = _context.MatchBets.ToList().Where(bet => bet.TeamId == teamId).Aggregate<BetMatch, uint>(0, (current, evt) => current + evt.Sum);

        totalSum = _context.TournamentsBets.ToList().Where(bet => bet.TeamId == teamId).Aggregate(totalSum, (current, evt) => current + evt.Sum);

        var stat = new TeamStatisticsInfo(teamId, totalWon, totalSum);
        return stat;
    }
    
    public uint GetMoneyBetTeamInEvent(IEnumerable<IBet> dbList, Guid teamId, Guid eventId) // получение кол-ва поинтов поставленных на команду для формирования коэфа
    {
        return dbList.Where(bet => bet.EventId == eventId && bet.TeamId == teamId).Aggregate<IBet, uint>(0, (current, bet) => current + bet.Sum);
    }

    private void CountStatistics(IEnumerable<IBet> dbList, Guid clientId, ref uint betsCount, ref uint wonCount,
        ref uint loseCount, ref uint totalSumWon, ref uint totalBetsSum)
    {
        foreach (var bet in dbList.Where(bet => bet.ClientId == clientId))
        {
            betsCount++;
            totalBetsSum += bet.Sum;
            if (bet.Result == BetResult.Lose)
                loseCount++;
            if (bet.Result != BetResult.Win) continue;
            wonCount++;
            totalSumWon += Enumerable.Aggregate(_context.Events!.Where(evt => evt.EventId == bet.EventId), totalSumWon,
                (current, evt) => (uint) (current + bet.Sum * evt.Coefficient));
        }
    }
    
}