using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Services
{
    public class SynonymServices : GenericRepository<Synonym>, ISynonymRepo
    {
        private readonly OncoDbContext _context;

        public SynonymServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Synonym>> GetSynonymsAsync()
        {
            return await _context.Synonyms
                .Include(s => s.Drugs)
                .ToListAsync();
        }

        public async Task<Synonym> GetSynonymByIdAsync(int id)
        {
            return await _context.Synonyms
                .Include(s => s.Drugs)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}