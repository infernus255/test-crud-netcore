using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using test_crud.core.Entities;
using test_crud.core.Interfaces;
using test_crud.infrastructure.Data;

namespace test_crud.infrastructure.Repositories
{
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {

        public SecurityRepository(TestCrudContext context) : base(context) { }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.TxtUser == login.TxtUser && x.TxtPassword == login.TxtPassword);
        }
    }
}
