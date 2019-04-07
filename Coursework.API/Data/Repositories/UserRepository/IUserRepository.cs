using Data.Repositories.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<Core.Models.Origin.User>
    {
        Task<Core.Models.Origin.User> GetByEmailAsync(string email);
    }
}
