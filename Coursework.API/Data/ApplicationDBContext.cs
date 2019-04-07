using Core.Entities.CrossTable;
using Core.Entities.Origin;
using Core.Models.Origin;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<BioMeasure> BioMeasures { get; set; }
        public DbSet<MatchBioMeasure> MatchBioMeasures { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<MatchBioMeasure>()
                .HasKey(src => new { src.MatchId, src.BioMeasureId });                

            base.OnModelCreating(builder);
        }
    }
}
