using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_crud.core.Entities;
using test_crud.core.Interfaces;
using test_crud.infrastructure.Data;

namespace test_crud.infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TestCrudContext context) : base(context) { }

        public async Task<IEnumerable<User>> GetUsersByRole(int roleId)
        {
            return await _entities.Where(user => user.RoleCode != null ? user.RoleCode == roleId : false).ToListAsync();
        }
    }
}
