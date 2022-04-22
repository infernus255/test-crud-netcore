using System.Threading.Tasks;
using test_crud.core.Entities;

namespace test_crud.core.Interfaces
{
    public interface ISecurityRepository : IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}