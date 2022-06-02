using WebApplication1.enums;

namespace WebApplication1.Models;

public class BetMatch : IBet
{
    public Guid Id { get; private init; }
    public Guid ClientId { get; private init; }
    public Guid EventId { get; private init; }
    public uint Sum { get; private init; }
    public Guid TeamId { get; private init; }
    public BetResult Result { get; private init; }

    public BetMatch(Guid id, Guid clientId, Guid eventId, uint sum, Guid teamId)
    {
        Id = id;
        ClientId = clientId;
        EventId = eventId;
        Sum = sum;
        TeamId = teamId;
        Result = BetResult.InProgress;
    }
}