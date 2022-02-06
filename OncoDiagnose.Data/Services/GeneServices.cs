using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Services
{
    public class GeneServices : GenericRepository<Gene>, IGeneRepo
    {
        private readonly OncoDbContext _context;

        public GeneServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Gene>> GetGenesAsync()
        {
            return await _context.Genes
                .Include(g => g.Aliases)
                .Include(g => g.Alterations)
                .ToListAsync();
        }

        public async Task<Gene> GetGeneByIdAsync(int id)
        {
            return await _context.Genes
                .Include(g => g.Aliases)
                .Include(g => g.Alterations)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
    }

}