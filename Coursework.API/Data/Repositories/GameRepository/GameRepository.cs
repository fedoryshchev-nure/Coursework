using Core.Entities.Origin;
using Data.Repositories.Generic;

namespace Data.Repositories.GameRepository
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
