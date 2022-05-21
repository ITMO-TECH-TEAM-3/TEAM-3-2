namespace WebApplication1.Models;

public class EventInfo
{
    public EventInfo(Guid clientId, List<float> coefficients)
    {
        ClientId = clientId;
        Coefficients = coefficients;
    }
    
    public Guid ClientId { get; }
    public List<float> Coefficients { get; }
}