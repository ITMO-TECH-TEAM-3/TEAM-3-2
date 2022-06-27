namespace WebApplication1.Models;

public class PlayerStatistics
{
    public PlayerStatistics(int kills)
    {
        Kills = kills;
    }

    public int Kills { get; }
    
}