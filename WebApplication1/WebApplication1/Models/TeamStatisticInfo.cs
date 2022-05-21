namespace WebApplication1.Models;

public class TeamStatisticsInfo
{
    public TeamStatisticsInfo(uint totalWon, uint defeats, uint totalBetsSum, uint wins, Guid teamId)
    {
        TotalWon = totalWon;
        TotalBetsSum = totalBetsSum;
        TeamId = teamId;
    }
    public Guid TeamId { get; }
    public uint TotalBetsSum { get; }
    public uint TotalWon { get; }

}