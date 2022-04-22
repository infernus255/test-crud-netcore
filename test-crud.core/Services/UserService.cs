using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_crud.core.CustomEntities;
using test_crud.core.Entities;
using test_crud.core.Exceptions;
using test_crud.core.Interfaces;
using test_crud.core.Options;
using test_crud.core.QueryFilters;

namespace test_crud.core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        public UserService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> paginationOptions)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = paginationOptions.Value;
        }
        public PagedList<User> Get(UserQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var users = _unitOfWork.UserRepository.GetAll();

            if (filters.TxtUser != null)
            {
                users = users.Where(user => user.TxtUser.ToLower().Contains(filters.TxtUser.ToLower()));
            }
            if (filters.TxtName != null)
            {
                users = users.Where(user => user.TxtName.ToLower().Contains(filters.TxtName.ToLower()));
            }
            if (filters.TxtLastName != null)
            {
                users = users.Where(user => user.TxtLastName.ToLower().Contains(filters.TxtLastName.ToLower()));
            }
            if (filters.IdentityCardNum != null)
            {
                users = users.Where(user => user.IdentityCardNum.ToLower().Contains(filters.IdentityCardNum.ToLower()));
            }
            if (filters.RoleCode != null)
            {
                users = users.Where(user => user.RoleCode == filters.RoleCode);
            }
            if (filters.IsActive != null)
            {
                users = users.Where(user => user.IsActive == filters.IsActive);
            }

            var pagedUsers = PagedList<User>.Create(users, filters.PageNumber, filters.PageSize);

            return pagedUsers;
        }
        public async Task<IEnumerable<User>> GetUsersByRole(User user)
        {
            return await _unitOfWork.UserRepository.GetUsersByRole(user.Role.Id);
        }
        public async Task<User> Get(int userId)
        {
            return await _unitOfWork.UserRepository.GetById(userId);
        }
        public async Task Post(User user)
        {
            if (user == null) new BusinessException("User can't be null");
            await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<bool> Put(User user)
        {
            if (user == null) new BusinessException("User can't be null");
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int userId)
        {
            await _unitOfWork.UserRepository.Delete(userId);
            return true;
        }
    }
}
