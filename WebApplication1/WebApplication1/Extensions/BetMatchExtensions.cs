using WebApplication1.Enums;
using WebApplication1.Models;

namespace WebApplication1.Extensions;

public static class BetMatchExtensions
{
    public static BetMatch UpdateWithResult(this BetMatch betMatch, BetResult result)
    {
        return new BetMatch(betMatch.Id,
            betMatch.ClientId,
            betMatch.EventId,
            betMatch.Sum,
            betMatch.TeamId,
            result);
    }
}