using Core.Entities.Origin;
using Data.Repositories.Generic;

namespace Data.Repositories.MatchRepository
{
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        public MatchRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
