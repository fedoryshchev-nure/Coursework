using Data.Repositories.BioMeasureRepository;
using Data.Repositories.GameRepository;
using Data.Repositories.MatchRepository;
using Data.Repositories.PlayerRepository;
using Data.Repositories.TeamRepository;
using Data.Repositories.UserRepository;
using System;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; set; }
        IBioMeasureRepository BioMeasures { get; set; }
        IGameRepository Games { get; set; }
        IMatchRepository Matches { get; set; }
        IPlayerRepository Players { get; set; }
        ITeamRepository Teams { get; set; }

        Task CompleteAsync();
    }
}
