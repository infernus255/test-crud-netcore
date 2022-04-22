using System.Threading.Tasks;
using test_crud.core.Entities;

namespace test_crud.core.Services
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
        Task RegisterUser(Security security);
    }
}