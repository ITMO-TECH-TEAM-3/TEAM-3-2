using System.Data.Common;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class EventUpdateService
{
    private readonly DatabaseContext _context;

    public EventUpdateService(DatabaseContext context)
    {
        _context = context;
    }

    public object? UpdateEventBase(Guid eventId, EventState eventState)
    {
        // eventId - id матча/турнира(?)
        // если eventState=1 запрещаем делать ставки на это событие
        // если eventState=2 в betMatch/betTournament меняем betResult
        return null;
    }
}