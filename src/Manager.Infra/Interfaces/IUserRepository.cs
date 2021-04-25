using Manager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<IList<User>> SearchByEmail(string email);
        Task<IList<User>> SearchByName(string name);
    }
}