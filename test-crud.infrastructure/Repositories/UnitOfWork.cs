using System.Threading.Tasks;
using test_crud.core.Entities;
using test_crud.core.Interfaces;
using test_crud.infrastructure.Data;

namespace test_crud.infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestCrudContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly ISecurityRepository _securityRepository;
        public UnitOfWork(TestCrudContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);

        public IRepository<Role> RoleRepository => _roleRepository ?? new BaseRepository<Role>(_context);

        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public async void DisposeAsync()
        {
            if (_context != null)
            {
                await _context.DisposeAsync();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
