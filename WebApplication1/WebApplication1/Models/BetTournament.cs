namespace WebApplication1.Models;

public class BetTournament : IBet
{
    public Guid Id { get; private init; }
    public Guid ClientId { get; private init; }
    public Guid EventId { get; private init; }
    public Guid TeamId { get; private init; }
    public uint Sum { get; private init; }
    public BetResult Result { get; private init;}
    public uint Place { get; private init; }
    public BetTournament(Guid id, Guid clientId, Guid eventId, uint sum, Guid teamId, uint place)
    {
        Id = id;
        ClientId = clientId;
        EventId = eventId;
        Sum = sum;
        TeamId = teamId;
        Place = place;
        Result = BetResult.InProgress;
    }

    
}