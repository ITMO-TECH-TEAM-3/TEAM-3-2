namespace WebApplication1.Models;

public class EventInfo
{
    public EventInfo(Guid eventId, List<float> coefficients)
    {
        EventId = eventId;
        Coefficients = coefficients;
    }
    
    public Guid EventId { get; }
    public List<float> Coefficients { get; }
}