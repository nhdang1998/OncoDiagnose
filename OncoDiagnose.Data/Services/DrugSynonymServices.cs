using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces;
using OncoDiagnose.Models;

namespace OncoDiagnose.DataAccess.Services
{
    public class DrugSynonymServices : GenericRepository<DrugSynonym>, IDrugSynonymRepo
    {
        private readonly OncoDbContext _context;

        public DrugSynonymServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DrugSynonym>> GetDrugSynonymsAsync()
        {
            return await _context.DrugSynonyms
                .AsNoTracking()
                .Include(ds => ds.Drug)
                .Include(ds => ds.Synonym)
                .ToListAsync();
        }

        public async Task<DrugSynonym> GetDrugSynonymAsync(int drugId, int synonymId)
        {
            return await _context.DrugSynonyms
                .AsNoTracking()
                .Include(ds => ds.Drug)
                .Include(ds => ds.Synonym)
                .FirstOrDefaultAsync(ds => ds.DrugId == drugId && ds.SynonymId == synonymId);
        }

        public IEnumerable<Drug> GetDrugs()
        {
            return _context.Drugs;
        }

        public IEnumerable<Synonym> GetSynonyms()
        {
            return _context.Synonyms;
        }
    }
}