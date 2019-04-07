using Core.Entities.Origin;
using Data.Repositories.Generic;

namespace Data.Repositories.TeamRepository
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
