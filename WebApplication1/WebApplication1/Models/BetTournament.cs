namespace WebApplication1.Models;

public class BetTournament : IBet
{
    public Guid BetId { get; private init; }
    public Guid ClientId { get; private init; }
    public Guid EventId { get; private init; }
    public Guid TeamId { get; private init; }
    public uint Sum { get; private init; }
    public BetResult Result { get; private init; }
    public uint Place { get; private init; }

    public BetTournament(Guid betId, Guid clientId, Guid eventId, uint sum, Guid teamId, uint place)
    {
        BetId = betId;
        ClientId = clientId;
        EventId = eventId;
        Sum = sum;
        TeamId = teamId;
        Place = place;
        Result = BetResult.InProgress;
    }
}