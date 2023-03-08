using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostInTime.Data
{
    public interface IRepository<T>
    {
        Task Add(T entity);
        Task Add(IEnumerable<T> entities);
        Task<T?> Get(int id);
        IQueryable<T> Get();
        Task Delete(T entity);
    }
}
