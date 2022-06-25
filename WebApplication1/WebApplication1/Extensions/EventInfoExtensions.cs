using WebApplication1.Enums;
using WebApplication1.Models;

namespace WebApplication1.Extensions;

public static class EventInfoExtensions
{
    public static EventInfo UpdateWithResult(this EventInfo eventInfo, EventResult result)
    {
        return new EventInfo(eventInfo.Id,
            eventInfo.EventId,
            eventInfo.Coefficient,
            eventInfo.TeamId,
            result,
            eventInfo.TotalSum);
    }
}