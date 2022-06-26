using WebApplication1.Enums;

namespace WebApplication1.Models;

public interface IBet
{
    public Guid Id { get; }
    public Guid ClientId { get; }
    public Guid EventId { get; }
    public Guid TeamId { get; }
    public uint Sum { get; }
    public BetResult Result { get; }
}