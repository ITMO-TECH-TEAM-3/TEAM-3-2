using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("/bets")]
public class BetsController : Controller
{
    private readonly BetsService _service;
    public BetsController(BetsService service) {
        _service = service;
    }
    [HttpPost]
    [Route("/create/match")]
    // returns BetMatch
    public IActionResult CreateBetOnMatch(Guid clientId, uint sum, Guid eventId, Guid teamId)
    {
        if (eventId == Guid.Empty || teamId == Guid.Empty || clientId == Guid.Empty || sum <= 0) return BadRequest();
        var result = _service.CreateBetOnMatch(clientId, sum, eventId, teamId);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }

    [HttpPost]
    [Route("/create/tournament")]
    // returns BetTournament
    public IActionResult CreateBetOnTournament(Guid clientId, uint sum, Guid eventId, Guid teamId, uint place)
    {
        if (eventId == Guid.Empty || teamId == Guid.Empty || clientId == Guid.Empty || sum <= 0) return BadRequest();
        var result = _service.CreateBetOnTournament(clientId, sum, eventId, teamId, place);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }
}