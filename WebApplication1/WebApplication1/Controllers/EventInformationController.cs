using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[ApiController]
[Route("/info")]
public class EventInformationController : Controller
{
    private readonly EventInformationService _service;
    public EventInformationController(EventInformationService service) {
        _service = service;
    }
    [HttpGet]
    [Route("/info/event")]
    // return IEnumerable<EventInfo>
    public IActionResult GetEventInfo(Guid eventId)
    {
        if (eventId == Guid.Empty) return StatusCode((int) HttpStatusCode.BadRequest);
        var result = _service.GetEventInfo(eventId);
        if (result != null && result.Any())
        {
            return Ok(result);
        }
        return NotFound();
    }

    [HttpGet]
    [Route("/info/client/bets/match")]
    // return List<BetMatch>
    public IActionResult GetListOfMatchBets(Guid clientId)
    {
        if (clientId == Guid.Empty) return StatusCode((int) HttpStatusCode.BadRequest);
        var result = _service.GetListOfMatchBets(clientId);
        if (result != null && result.Any())
        {
            return Ok(result);
        }
        return NotFound();
    }

    [HttpGet]
    [Route("/info/client/bets/tournament")]
    // return List<BetTournament>
    public IActionResult GetListOfTournamentBets(Guid clientId)
    {
        if (clientId == Guid.Empty) return StatusCode((int) HttpStatusCode.BadRequest);
        var result = _service.GetListOfTournamentBets(clientId);
        if (result != null && result.Any())
        {
            return Ok(result);
        }
        return NotFound();
    }
}