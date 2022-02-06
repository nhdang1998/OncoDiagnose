using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces.Base
{
    public interface IGenericRepository<T>
    {
        Task<T> GetByIdAsync(int? id);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null);

        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null,
            string includeProperties = null);

        void Add(T entity);

        void Update(T entity);
        void Remove(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}