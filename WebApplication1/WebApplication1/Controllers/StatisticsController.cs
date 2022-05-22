using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;
[ApiController]
[Route("/statistics")]
public class StatisticsController : Controller
{
    [HttpGet]
    [Route("/statistics/client")]
    public IActionResult GetClientStatistics(Guid clientId)
    {
        return StatusCode(501);
    }

    [HttpGet]
    [Route("/statistics/team")]
    public IActionResult GetTeamStatistics(Guid teamId)
    {
        return StatusCode(501);
    }
}