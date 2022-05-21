namespace WebApplication1.Models;

public class ClientStatisticsInfo
{
    public ClientStatisticsInfo(uint totalWon, uint defeats, uint totalBetsSum, uint wins, Guid clientId)
    {
        TotalWon = totalWon;
        Defeats = defeats;
        TotalBetsSum = totalBetsSum;
        Wins = wins;
        ClientId = clientId;
    }
    public Guid ClientId { get; }
    public uint Wins { get; }
    public uint Defeats { get; }
    public uint TotalBetsSum { get; }
    public uint TotalWon { get; }
}