namespace WebApplication1.Models;

public class MatchResult
{
    public MatchResult(bool isDraw, Guid winnerTeamId)
    {
        IsDraw = isDraw;
        WinnerTeamId = winnerTeamId;
    }

    public bool IsDraw { get; private init; }
    public Guid WinnerTeamId { get; private init; }
}