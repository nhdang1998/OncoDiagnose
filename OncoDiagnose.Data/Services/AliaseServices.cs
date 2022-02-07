using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Services
{
    public class AliaseServices : GenericRepository<Aliase>, IAliaseRepo
    {
        private readonly OncoDbContext _context;

        public AliaseServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Aliase>> GetAliasesAsync()
        {
            return await _context.Aliases
                .Include(a => a.GeneAliases)
                .ThenInclude(ga => ga.Gene)
                .ToListAsync();
        }

        public async Task<Aliase> GetAliaseByIdAsync(int id)
        {
            return await _context.Aliases
                .Include(a => a.GeneAliases)
                .ThenInclude(ga => ga.Gene)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}