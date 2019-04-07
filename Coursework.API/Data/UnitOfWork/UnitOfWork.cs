using System.Threading.Tasks;
using Data.Repositories.BioMeasureRepository;
using Data.Repositories.GameRepository;
using Data.Repositories.MatchRepository;
using Data.Repositories.PlayerRepository;
using Data.Repositories.TeamRepository;
using Data.Repositories.UserRepository;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository Users { get; set; }
        public IBioMeasureRepository BioMeasures { get; set; }
        public IGameRepository Games { get; set; }
        public IMatchRepository Matches { get; set; }
        public IPlayerRepository Players { get; set; }
        public ITeamRepository Teams { get; set; }

        private readonly ApplicationDBContext context;

        public UnitOfWork(ApplicationDBContext context)
        {
            this.context = context;
            Users = new UserRepository(context);
            BioMeasures = new BioMeasureRepository(context);
            Games = new GameRepository(context);
            Matches = new MatchRepository(context);
            Players = new PlayerRepository(context);
            Teams = new TeamRepository(context);
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
