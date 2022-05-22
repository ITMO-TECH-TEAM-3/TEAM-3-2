namespace WebApplication1.Models;

public class TeamStatisticsInfo
{
    public TeamStatisticsInfo(Guid teamId, uint totalWon, uint totalBetsSum)
    {
        TotalWon = totalWon;
        TotalBetsSum = totalBetsSum;
        TeamId = teamId;
    }
    public Guid TeamId { get; }
    public uint TotalBetsSum { get; }
    public uint TotalWon { get; }

}