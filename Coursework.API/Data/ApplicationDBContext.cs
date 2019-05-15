using Core.Entities.Origin;
using Core.Models.Origin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<BioMeasure> BioMeasures { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            Seed(builder);

            base.OnModelCreating(builder);
        }

        private void Seed(ModelBuilder builder)
        {
            SeedRoles(builder);

            SeedTeams(builder);
            SeedPlayers(builder);
            SeedGames(builder);
            SeedMatches(builder);
            SeedBioMeasures(builder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            const string admin = "Admin",
                user = "User";

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = admin, NormalizedName = admin.ToUpper() },
                new IdentityRole { Name = user, NormalizedName = user.ToUpper() });
        }

        private void SeedTeams(ModelBuilder builder)
        {
            builder.Entity<Team>().HasData(
                new Team { Id = "1", Name = "Team one" },
                new Team{ Id = "2", Name = "Team two" });
        }

        private void SeedPlayers(ModelBuilder builder)
        {
            builder.Entity<Player>().HasData(
                new Player { Id = "1", Nickname = "Player 1", FirstName = "FirstName", LastName = "LastName", DateOfBirth = DateTime.Now, TeamId = "1" },
                new Player { Id = "2", Nickname = "Player 2", FirstName = "FirstName", LastName = "LastName", DateOfBirth = DateTime.Now, TeamId = "1" },
                new Player { Id = "3", Nickname = "Player 3", FirstName = "FirstName", LastName = "LastName", DateOfBirth = DateTime.Now, TeamId = "1" },
                new Player { Id = "4", Nickname = "Player 4", FirstName = "FirstName", LastName = "LastName", DateOfBirth = DateTime.Now, TeamId = "1" },
                new Player { Id = "5", Nickname = "Player 5", FirstName = "FirstName", LastName = "LastName", DateOfBirth = DateTime.Now, TeamId = "1" },

                new Player { Id = "6", Nickname = "Player 6", FirstName = "FirstName", LastName = "LastName", DateOfBirth = DateTime.Now, TeamId = "2" },
                new Player { Id = "7", Nickname = "Player 7", FirstName = "FirstName", LastName = "LastName", DateOfBirth = DateTime.Now, TeamId = "2" },
                new Player { Id = "8", Nickname = "Player 8", FirstName = "FirstName", LastName = "LastName", DateOfBirth = DateTime.Now, TeamId = "2" },
                new Player { Id = "9", Nickname = "Player 9", FirstName = "FirstName", LastName = "LastName", DateOfBirth = DateTime.Now, TeamId = "2" },
                new Player { Id = "10", Nickname = "Player 10", FirstName = "FirstName", LastName = "LastName", DateOfBirth = DateTime.Now, TeamId = "2" });
        }

        private void SeedGames(ModelBuilder builder)
        {
            builder.Entity<Game>().HasData(
                new Game { Id = "1", Name = "Game one", Description = "Game one description", DateReleased = DateTime.Now },
                new Game { Id = "2", Name = "Game two", Description = "Game two description", DateReleased = DateTime.Now });
        }

        private void SeedMatches(ModelBuilder builder)
        {
            builder.Entity<Match>().HasData(
                new Match { Id = "1", Date = DateTime.Now, MatchResult = Match.Result.FirstTeamWon, GameId = "1", TeamOneId = "1", TeamTwoId = "2" },
                new Match { Id = "2", Date = DateTime.Now, MatchResult = Match.Result.None, GameId = "1", TeamOneId = "1", TeamTwoId = "2" });
        }

        private void SeedBioMeasures(ModelBuilder builder)
        {
            builder.Entity<BioMeasure>().HasData(
                new BioMeasure { Id = "1", Pulse = 90, Pressure = 80, DateMeasured = DateTime.Now, MatchId = "1", PlayerId = "1" },
                new BioMeasure { Id = "2", Pulse = 100, Pressure = 90, DateMeasured = DateTime.Now, MatchId = "1", PlayerId = "2" },
                new BioMeasure { Id = "3", Pulse = 95, Pressure = 75, DateMeasured = DateTime.Now, MatchId = "1", PlayerId = "3" },
                new BioMeasure { Id = "4", Pulse = 70, Pressure = 80, DateMeasured = DateTime.Now, MatchId = "1", PlayerId = "4" },
                new BioMeasure { Id = "5", Pulse = 80, Pressure = 84, DateMeasured = DateTime.Now, MatchId = "1", PlayerId = "5" },

                new BioMeasure { Id = "6", Pulse = 40, Pressure = 150, DateMeasured = DateTime.Now, MatchId = "1", PlayerId = "6" },
                new BioMeasure { Id = "7", Pulse = 160, Pressure = 160, DateMeasured = DateTime.Now, MatchId = "1", PlayerId = "7" },
                new BioMeasure { Id = "8", Pulse = 20, Pressure = 30, DateMeasured = DateTime.Now, MatchId = "1", PlayerId = "8" },
                new BioMeasure { Id = "9", Pulse = 67, Pressure = 62, DateMeasured = DateTime.Now, MatchId = "1", PlayerId = "9" },
                new BioMeasure { Id = "10", Pulse = 400, Pressure = 400, DateMeasured = DateTime.Now, MatchId = "1", PlayerId = "10" },

                new BioMeasure { Id = "11", Pulse = 80, Pressure = 100, DateMeasured = DateTime.Now, MatchId = "2", PlayerId = "1" },
                new BioMeasure { Id = "12", Pulse = 90, Pressure = 83, DateMeasured = DateTime.Now, MatchId = "2", PlayerId = "2" },
                new BioMeasure { Id = "13", Pulse = 87, Pressure = 120, DateMeasured = DateTime.Now, MatchId = "2", PlayerId = "3" },
                new BioMeasure { Id = "14", Pulse = 120, Pressure = 70, DateMeasured = DateTime.Now, MatchId = "2", PlayerId = "4" },
                new BioMeasure { Id = "15", Pulse = 90, Pressure = 80, DateMeasured = DateTime.Now, MatchId = "2", PlayerId = "5" },

                new BioMeasure { Id = "16", Pulse = 150, Pressure = 140, DateMeasured = DateTime.Now, MatchId = "2", PlayerId = "6" },
                new BioMeasure { Id = "17", Pulse = 60, Pressure = 60, DateMeasured = DateTime.Now, MatchId = "2", PlayerId = "7" },
                new BioMeasure { Id = "18", Pulse = 30, Pressure = 200, DateMeasured = DateTime.Now, MatchId = "2", PlayerId = "8" },
                new BioMeasure { Id = "19", Pulse = 79, Pressure = 100, DateMeasured = DateTime.Now, MatchId = "2", PlayerId = "9" },
                new BioMeasure { Id = "20", Pulse = 93, Pressure = 87, DateMeasured = DateTime.Now, MatchId = "2", PlayerId = "10" });
        }
    }
}
