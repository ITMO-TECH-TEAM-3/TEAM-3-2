namespace WebApplication1.Models;

public interface IBet
{
    public Guid ClientId { get; }
    public Guid EventId { get; }
    public Guid TeamId { get; }

    public uint Sum { get; }
}