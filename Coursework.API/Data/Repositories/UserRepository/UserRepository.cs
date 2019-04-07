using Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<Core.Models.Origin.User>, IUserRepository
    {
        public UserRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<Core.Models.Origin.User> GetByEmailAsync(string email)
        {
            return await Set.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
