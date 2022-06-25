using WebApplication1.Enums;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class UpdateEventResultService
{
    private readonly DatabaseContext _context;

    public UpdateEventResultService(DatabaseContext context)
    {
        _context = context;
    }

    public void UpdateMatchResult(Guid eventId, MatchResult result)
    {
        if (_context.Events == null) return;
        
        var events = _context.Events.Where(evt => evt.EventId == eventId);

        foreach (var eventInfo in events)
        {
            if (eventInfo.Result != EventResult.InProgress && eventInfo.Result != EventResult.NotStarted)
                continue;
            
            var eventResult = EventResult.Lose;
            
            if (result.WinnerTeamId == eventInfo.TeamId)
                eventResult = EventResult.Win;

            if (result.IsDraw)
                eventResult = EventResult.Draw;
            
            var updatedEvent = eventInfo.UpdateWithResult(eventResult);
            
            _context.Events.Remove(eventInfo);
            _context.Events.Add(updatedEvent);
        }

        if (_context.MatchBets != null)
        {
            var bets = _context.MatchBets.Where(bet => bet.EventId == eventId);
            foreach (var betMatch in bets)
            {
                if (betMatch.Result != BetResult.InProgress)
                    continue;
                var betResult = BetResult.Lose;
                if (result.WinnerTeamId == betMatch.TeamId)
                    betResult = BetResult.Win;

                var updatedBet = betMatch.UpdateWithResult(betResult);

                _context.MatchBets.Remove(betMatch);
                _context.MatchBets.Add(updatedBet);
            }
        }

        _context.SaveChanges();
    }

    public void UpdateTournamentResult(Guid eventId, Guid winnerTeamId)
    {
        if (_context.Events == null) return;
        
        var events = _context.Events.Where(evt => evt.EventId == eventId);

        foreach (var eventInfo in events)
        {
            if (eventInfo.Result != EventResult.InProgress && eventInfo.Result != EventResult.NotStarted)
                continue;
            
            var eventResult = EventResult.Lose;
            
            if (winnerTeamId == eventInfo.TeamId)
                eventResult = EventResult.Win;
            
            var updatedEvent = eventInfo.UpdateWithResult(eventResult);
            
            _context.Events.Remove(eventInfo);
            _context.Events.Add(updatedEvent);
        }

        if (_context.TournamentsBets != null)
        {
            var bets = _context.TournamentsBets.Where(bet => bet.EventId == eventId);
            foreach (var betTournament in bets)
            {
                if (betTournament.Result != BetResult.InProgress)
                    continue;
                
                var betResult = BetResult.Lose;
                if (winnerTeamId == betTournament.TeamId)
                    betResult = BetResult.Win;

                var updatedBet = betTournament.UpdateWithResult(betResult);

                _context.TournamentsBets.Remove(betTournament);
                _context.TournamentsBets.Add(updatedBet);
            }
        }

        _context.SaveChanges();
    }
}