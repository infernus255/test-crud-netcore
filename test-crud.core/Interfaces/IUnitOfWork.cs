using System;
using System.Threading.Tasks;
using test_crud.core.Entities;

namespace test_crud.core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IRepository<Role> RoleRepository { get; }
        ISecurityRepository SecurityRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
