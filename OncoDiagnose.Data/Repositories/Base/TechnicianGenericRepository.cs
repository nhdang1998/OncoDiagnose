using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.DataAccess.TechnicianData;

namespace OncoDiagnose.DataAccess.Repositories.Base
{
    public class TechnicianGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TechnicianDbContext _context;

        public TechnicianGenericRepository(TechnicianDbContext context)
        {
            _context = context;
        }

        public TechnicianGenericRepository()
        {
            
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
