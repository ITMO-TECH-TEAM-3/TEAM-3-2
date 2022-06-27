using System.Security.Cryptography;

namespace WebApplication1.Models;

public class PlayerInfo
{
    public PlayerInfo(Guid id, string name, Guid userId, PlayerStatistics playerStatistics)
    {
        Id = id;
        Name = name;
        UserId = userId;
        PlayerStatistics = playerStatistics;
    }

    public Guid Id { get; }
    public string Name { get; }
    public Guid UserId { get; }
    public PlayerStatistics PlayerStatistics { get; }
}