namespace WebApplication1.Models;

public class Match
{
    
    public Guid Id { get; private init; }
    public Guid ResultId { get; private init; }
    public int Round { get; private init; }
    public DateTime StartDateTime { get; private init; }
    public Guid Team1Id { get; private init; }
    public Guid Team2Id { get; private init; }
    
    public Match(Guid id, Guid resultId, int round, DateTime startDateTime, Guid team1Id, Guid team2Id)
    {
        Id = id;
        ResultId = resultId;
        Round = round;
        StartDateTime = startDateTime;
        Team1Id = team1Id;
        Team2Id = team2Id;
    }
}