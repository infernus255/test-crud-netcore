using System.Collections.Generic;
using System.Threading.Tasks;
using test_crud.core.CustomEntities;
using test_crud.core.Entities;
using test_crud.core.QueryFilters;

namespace test_crud.core.Services
{
    public interface IUserService
    {
        Task<bool> Delete(int userCode);
        PagedList<User> Get(UserQueryFilter filters);
        Task<IEnumerable<User>> GetUsersByRole(User user);
        Task<User> Get(int userCode);
        Task Post(User user);
        Task<bool> Put(User user);
    }
}