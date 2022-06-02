using WebApplication1.enums;

namespace WebApplication1.Models;

public class EventInfo
{
    public EventInfo(Guid id, Guid eventId, double coefficient, Guid teamId, EventResult result)
    {
        Id = id;
        EventId = eventId;
        Coefficient = coefficient;
        TeamId = teamId;
        Result = result;
    }

    public Guid Id { get; private init; }
    public Guid EventId { get; private init; }
    public double Coefficient { get; private init; }
    public Guid TeamId { get; private init; }
    public EventResult Result { get; private init; }
}