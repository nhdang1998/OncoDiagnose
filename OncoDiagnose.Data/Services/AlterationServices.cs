using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Services
{
    public class AlterationServices : GenericRepository<Alteration>, IAlterationRepo
    {
        private readonly OncoDbContext _context;

        public AlterationServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Alteration>> GetAlterationsAsync()
        {
            return await _context.Alterations
                .AsNoTracking()
                .Include(a => a.Gene)
                .Include(a => a.Mutation)
                .Include(a => a.Consequence)
                .ToListAsync();
        }

        public async Task<Alteration> GetAlterationByIdAsync(int id)
        {
            return await _context.Alterations
                .AsNoTracking()
                .Include(a => a.Gene)
                .Include(a => a.Mutation)
                .Include(a => a.Consequence)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public IEnumerable<Mutation> GetMutations()
        {
            return _context.Mutations;
        }

        public IEnumerable<Gene> GetGenes()
        {
            return _context.Genes;
        }

        public IEnumerable<Consequence> GetConsequences()
        {
            return _context.Consequences;
        }
    }
}