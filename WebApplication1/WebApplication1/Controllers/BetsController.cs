using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
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
    public async Task<BetMatch> CreateBetOnMatch(Guid clientId, uint sum, Guid eventId, Guid teamId)
    {
        return await _service.CreateBetOnMatch(clientId, sum, eventId, teamId);
    }

    [HttpPost]
    [Route("/create/tournament")]
    // returns BetTournament
    public async Task<BetTournament> CreateBetOnTournament(Guid clientId, uint sum, Guid eventId, Guid teamId, uint place)
    {
        return await _service.CreateBetOnTournament(clientId, sum, eventId, teamId, place);
    }
}