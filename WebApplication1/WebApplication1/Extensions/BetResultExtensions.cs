using WebApplication1.Enums;

namespace WebApplication1.Extensions;

public static class BetResultExtensions
{
    public static EventResult ToEventResult(this BetResult result)
    {
        return result switch
        {
            BetResult.Lose => EventResult.Lose,
            BetResult.Win => EventResult.Win,
            BetResult.InProgress => EventResult.InProgress,
            _ => throw new ArgumentOutOfRangeException(nameof(result), result, null)
        };
    }
}