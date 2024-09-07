using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmpAPI.DAL.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> Get(long id);
        Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task<bool> Add(T entity);
        Task<bool> DeleteEntity(long id);
        Task<bool> UpdateEntity(T entity);
    }
}
