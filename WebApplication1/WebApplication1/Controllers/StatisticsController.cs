using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;
[ApiController]
[Route("/statistics")]
public class StatisticsController : Controller
{
    private readonly StatisticsService _service;
    public StatisticsController(StatisticsService service) {
        _service = service;
    }
    [HttpGet]
    [Route("/statistics/client")]
    public IActionResult GetClientStatistics(Guid clientId)
    {
        if (clientId == Guid.Empty) return BadRequest();
        var result = _service.GetClientStatistics(clientId);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }

    [HttpGet]
    [Route("/statistics/team")]
    public IActionResult GetTeamStatistics(Guid teamId)
    {
        if (teamId == Guid.Empty) return BadRequest();
        var result = _service.GetTeamStatistics(teamId);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }
}