using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;
[ApiController]
[Route("/info")]
public class EventInformationController : Controller
{
    [HttpGet]
    [Route("/info/event")]
    // return EventInfo
    public IActionResult GetEventInfo(Guid eventId)
    {
        return StatusCode(501);
    }

    [HttpGet]
    [Route("/info/client/bets/match")]
    // return List<BetMatch>
    public IActionResult GetListOfMatchBets(Guid clientId)
    {
        return StatusCode(501);
    }

    [HttpGet]
    [Route("/info/client/bets/tournament")]
    // return List<BetTournament>
    public IActionResult GetListOfTournamentBets(Guid clientId)
    {
        return StatusCode(501);
    }
}