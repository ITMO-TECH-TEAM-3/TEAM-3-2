namespace WebApplication1.Models;

public class BetMatch : IBet
{
    public BetMatch(Guid clientId, Guid eventId, uint sum, Guid teamId)
    {
        ClientId = clientId;
        EventId = eventId;
        Sum = sum;
        TeamId = teamId;
    }

    public Guid ClientId { get; }
    public Guid EventId { get; }
    public Guid TeamId { get; }
    public uint Sum { get; }

}
