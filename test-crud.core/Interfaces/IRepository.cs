using System.Collections.Generic;
using System.Threading.Tasks;
using test_crud.core.Entities;

namespace test_crud.core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int id);
    }
}
