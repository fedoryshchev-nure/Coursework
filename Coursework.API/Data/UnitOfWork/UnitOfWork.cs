using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Origin;
using Core.Models;
using Core.Models.Origin;
using Data.Repositories.BioMeasureRepository;
using Data.Repositories.GameRepository;
using Data.Repositories.Generic;
using Data.Repositories.MatchRepository;
using Data.Repositories.PlayerRepository;
using Data.Repositories.TeamRepository;
using Data.Repositories.UserRepository;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext context;
        private readonly IDictionary<Type, object>
            repositories;

        public IUserRepository Users { get => repositories[typeof(User)] as IUserRepository; }
        public IBioMeasureRepository BioMeasures { get => repositories[typeof(BioMeasure)] as IBioMeasureRepository; }
        public IGameRepository Games { get => repositories[typeof(Game)] as IGameRepository; }
        public IMatchRepository Matches { get => repositories[typeof(Match)] as IMatchRepository; }
        public IPlayerRepository Players { get => repositories[typeof(Player)] as IPlayerRepository; }
        public ITeamRepository Teams { get => repositories[typeof(Team)] as ITeamRepository; }

        public UnitOfWork(ApplicationDBContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>
            {
                {typeof(User), new UserRepository(context) },
                {typeof(BioMeasure), new BioMeasureRepository(context) },
                {typeof(Game), new GameRepository(context) },
                {typeof(Match), new MatchRepository(context) },
                {typeof(Player), new PlayerRepository(context) },
                {typeof(Team), new TeamRepository(context) }
            };
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() 
            where TEntity : class, IEntity
        {
            return (GenericRepository<TEntity>)repositories[typeof(TEntity)];
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
