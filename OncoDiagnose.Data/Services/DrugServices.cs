using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Services
{
    public class DrugServices : GenericRepository<Drug>, IDrugRepo
    {
        private readonly OncoDbContext _context;

        public DrugServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Drug>> GetDrugsAsync()
        {
            return await _context.Drugs
                .Include(d => d.Synonyms)
                .Include(d => d.Treatments)
                .ToListAsync();
        }

        public async Task<Drug> GetDrugByIdAsync(int id)
        {
            return await _context.Drugs
                .AsNoTracking()
                .Include(d => d.Synonyms)
                .Include(d => d.Treatments)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public IEnumerable<Treatment> GetTreatments()
        {
            return _context.Treatments;
        }

        public IEnumerable<Synonym> GetSynonyms()
        {
            return _context.Synonyms;
        }
    }
}