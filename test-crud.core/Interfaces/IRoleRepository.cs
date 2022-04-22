using System.Threading.Tasks;
using test_crud.core.Entities;

namespace test_crud.core.Interfaces
{
    public interface IRoleRepository
    {
        Task<bool> Exists(int roleCode);
        Task<Role> Get(int roleCode);
    }
}
