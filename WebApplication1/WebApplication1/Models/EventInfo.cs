using WebApplication1.Enums;

namespace WebApplication1.Models;

public class EventInfo
{
    public EventInfo(Guid id, Guid eventId, double coefficient, Guid teamId, EventResult result, uint totalSum)
    {
        Id = id;
        EventId = eventId;
        Coefficient = coefficient;
        TeamId = teamId;
        Result = result;
        TotalSum = totalSum;
    }

    public Guid Id { get; private init; }
    public Guid EventId { get; private init; }
    public double Coefficient { get; private init; }
    public Guid TeamId { get; private init; }
    public EventResult Result { get; private init; }
    public uint TotalSum { get; private init; }
}