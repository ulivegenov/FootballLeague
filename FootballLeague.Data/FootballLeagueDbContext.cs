namespace FootballLeague.Data
{
    using FootballLeague.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class FootballLeagueDbContext : DbContext
    {
        public FootballLeagueDbContext(DbContextOptions<FootballLeagueDbContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                        .HasOne(g => g.HomeTeam)
                        .WithMany(ht => ht.HomeGames)
                        .IsRequired(true)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                        .HasOne(g => g.AwayTeam)
                        .WithMany(at => at.AwayGames)
                        .IsRequired(true)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
