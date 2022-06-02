using WebApplication1.Enums;

namespace WebApplication1.Models;
// нужен, чтобы принимать информацию с сервера турниров
public class TournamentInfo
{
    public Guid Id { get; private init; }
    public Guid CreatorId { get; private init; }
    public TournamentType TournamentType { get; private init; }
    public List<Guid> Teams { get; private init; }
    public DateTime StartDateTime { get; private init; }
    public BetResult TournamentStatus { get; private init; }
}