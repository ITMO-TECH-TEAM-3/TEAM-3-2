using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1;

public sealed class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<BetMatch>? MatchBets { get; set; }
    public DbSet<BetTournament>? TournamentsBets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BetMatch>().ToTable("MatchBets");
        modelBuilder.Entity<BetTournament>().ToTable("TournamentBets");
        base.OnModelCreating(modelBuilder);
    }
}