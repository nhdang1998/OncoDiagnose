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
                .Include(a => a.Genes)
                .ToListAsync();
        }

        public async Task<Aliase> GetAliaseByIdAsync(int id)
        {
            return await _context.Aliases
                .AsNoTracking()
                .Include(a => a.GeneAliases)
                .Include(a => a.Genes)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}