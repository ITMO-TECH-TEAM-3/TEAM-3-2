namespace WebApplication1.Models;

public class EventInfo
{
    public EventInfo(Guid id, Guid eventId, double coefficient, Guid teamId)
    {
        Id = id;
        EventId = eventId;
        Coefficient = coefficient;
        TeamId = teamId;
    }

    public Guid Id { get; private init; }
    public Guid EventId { get; private init;  }
    public double Coefficient { get; private init;  }
    public Guid TeamId { get; private init;  }
}