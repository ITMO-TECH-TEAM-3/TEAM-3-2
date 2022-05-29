using WebApplication1.Models;

namespace WebApplication1.Services;

public class StatisticsService
{
    private readonly DatabaseContext _context;

    public StatisticsService(DatabaseContext context) {
        _context = context;
    }
    public ClientStatisticsInfo? GetClientStatistics(Guid clientId)
    {
        return null;
    }
    
    public TeamStatisticsInfo? GetTeamStatistics(Guid teamId)
    {
        return null;
    }
}