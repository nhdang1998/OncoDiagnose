using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Services
{
    public class MutationServices : GenericRepository<Mutation>, IMutationRepo
    {
        private readonly OncoDbContext _context;

        public MutationServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Mutation>> GetMutationsAsync()
        {
            return await _context.Mutations
                .Include(m => m.CancerType)
                .Include(m => m.MutationArticles)
                .ThenInclude(ma => ma.Article)
                .Include(m => m.Alterations)
                .Include(m => m.Treatments)
                .ToListAsync();
        }

        public async Task<Mutation> GetMutationByIdAsync(int id)
        {
            return await _context.Mutations
                .Include(m => m.CancerType)
                .Include(m => m.MutationArticles)
                .ThenInclude(ma => ma.Article)
                .Include(m => m.Alterations)
                .Include(m => m.Treatments)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}