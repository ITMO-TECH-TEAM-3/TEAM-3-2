using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;
[ApiController]
[Route("/bets")]
public class BetsController : Controller
{
    [HttpPost]
    [Route("/create/match")]
    // returns BetMatch
    public IActionResult CreateBetOnMatch(Guid clientId, uint sum, Guid eventId, Guid teamId)
    {
        // This status code is similar to NotImplementedException
        return StatusCode(501);
    }

    [HttpPost]
    [Route("/create/tournament")]
    // returns BetTournament
    public IActionResult CreateBetOnTournament(Guid clientId, uint sum, Guid eventId, Guid teamId, uint place)
    {
        return StatusCode(501);
    }
}