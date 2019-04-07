using Core.Entities.Origin;
using Data.Repositories.Generic;

namespace Data.Repositories.PlayerRepository
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
