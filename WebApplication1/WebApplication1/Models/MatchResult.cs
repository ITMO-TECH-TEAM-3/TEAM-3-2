namespace WebApplication1.Models;

public class MatchResult
{
    public MatchResult(bool isDraw, Guid winnerTeamId, int firstScore, int secondScore)
    {
        IsDraw = isDraw;
        WinnerTeamId = winnerTeamId;
        FirstScore = firstScore;
        SecondScore = secondScore;
    }

    public bool IsDraw { get; private init; }
    public Guid WinnerTeamId { get; private init; }
    public int FirstScore { get; private init; }
    public int SecondScore { get; private init; }
}