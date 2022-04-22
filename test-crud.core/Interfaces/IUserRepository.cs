using System.Collections.Generic;
using System.Threading.Tasks;
using test_crud.core.Entities;

namespace test_crud.core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetUsersByRole(int roleId);
    }
}
