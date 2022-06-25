using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[ApiController]
[Route("/route")]
public class UpdateController : Controller
{
   private readonly UpdateEventResultService _service;

  
   public UpdateController(UpdateEventResultService service)
   {
      _service = service;
   }
   
   [HttpPatch]
   [Route("/route/update/match")]
   public IActionResult UpdateMatchResult(Guid matchId, MatchResult result)
   {
      _service.UpdateMatchResult(matchId, result);
      return Ok();
   }
   
   [HttpPatch]
   [Route("/route/update/tournament")]
   public IActionResult UpdateTournamentResult(Guid tournamentId, Guid winnerTeamId)
   {
      _service.UpdateTournamentResult(tournamentId, winnerTeamId);
      return Ok();
   }
}