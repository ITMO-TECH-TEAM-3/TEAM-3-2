namespace WebApplication1.Models;

public class TeamStatisticsInfo
{
    public TeamStatisticsInfo(Guid teamId, uint totalWon, uint totalBetsSum)
    {
        TeamId = teamId;
        TotalWon = totalWon;
        TotalBetsSum = totalBetsSum;
    }

    public Guid TeamId { get; }
    public uint TotalWon { get; }
    public uint TotalBetsSum { get; }
}