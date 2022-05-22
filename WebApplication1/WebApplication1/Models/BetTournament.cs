namespace WebApplication1.Models;

public class BetTournament : IBet
{
    public BetTournament(Guid clientId, Guid eventId, uint sum, Guid teamId, uint place)
    {
        ClientId = clientId;
        EventId = eventId;
        Sum = sum;
        TeamId = teamId;
        Place = place;
    }

    public Guid ClientId { get; }
    public Guid EventId { get; }
    public Guid TeamId { get; }
    public uint Sum { get; }
    public uint Place { get; }


}