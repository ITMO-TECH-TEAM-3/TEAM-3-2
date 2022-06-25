using WebApplication1.Enums;
using WebApplication1.Models;

namespace WebApplication1.Extensions;

public static class BetTournamentExtension
{
    public static BetTournament UpdateWithResult(this BetTournament betTournament, BetResult result)
    {
        return new BetTournament(betTournament.Id,
            betTournament.ClientId,
            betTournament.EventId,
            betTournament.Sum,
            betTournament.TeamId,
            result);
    }
}