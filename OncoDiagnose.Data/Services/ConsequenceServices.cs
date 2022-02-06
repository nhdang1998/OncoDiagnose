using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Services
{
    public class ConsequenceServices : GenericRepository<Consequence>, IConsequenceRepo
    {
        private readonly OncoDbContext _context;

        public ConsequenceServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Consequence>> GetConsequencesAsync()
        {
            return await _context.Consequences
                .AsNoTracking()
                .Include(c => c.Alterations)
                .ToListAsync();
        }

        public async Task<Consequence> GetConsequenceByIdAsync(int id)
        {
            return await _context.Consequences
                .AsNoTracking()
                .Include(c => c.Alterations)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

    }
}