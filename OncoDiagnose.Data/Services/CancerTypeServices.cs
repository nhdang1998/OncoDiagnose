using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Services
{
    public class CancerTypeServices : GenericRepository<CancerType>, ICancerTypeRepo
    {
        private readonly OncoDbContext _context;

        public CancerTypeServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CancerType> GetCancerTypeByIdAsync(int id)
        {
            return await _context.CancerTypes
                .AsNoTracking()
                .Include(ct => ct.Mutations)
                .FirstOrDefaultAsync(ct => ct.Id == id);
        }

        public async Task<IReadOnlyList<CancerType>> GetCancerTypesAsync()
        {
            return await _context.CancerTypes
                .AsNoTracking()
                .Include(ct => ct.Mutations)
                .ToListAsync();
        }

        public IEnumerable<Mutation> GetMutations()
        {
            return _context.Mutations;
        }
    }
}