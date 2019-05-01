using Core.Models;
using Data.Repositories.BioMeasureRepository;
using Data.Repositories.GameRepository;
using Data.Repositories.Generic;
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
        IUserRepository Users { get; }
        IBioMeasureRepository BioMeasures { get; }
        IGameRepository Games { get; }
        IMatchRepository Matches { get; }
        IPlayerRepository Players { get; }
        ITeamRepository Teams { get; }

        IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, IEntity;

        Task CompleteAsync();
    }
}
