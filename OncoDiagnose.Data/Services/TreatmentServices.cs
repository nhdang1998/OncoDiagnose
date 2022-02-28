using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Services
{
    public class TreatmentServices : GenericRepository<Treatment>, ITreatmentRepo
    {
        private readonly OncoDbContext _context;

        public TreatmentServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Treatment>> GetTreatmentsAsync()
        {
            return await _context.Treatments
                .Include(t => t.Mutation)
                .ThenInclude(m => m.CancerType)
                .Include(t => t.TreatmentDrugs)
                .ThenInclude(td => td.Drug)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Treatment> GetTreatmentByIdAsync(int id)
        {
            return await _context.Treatments
                .Include(t => t.Mutation)
                .Include(t => t.TreatmentDrugs)
                .ThenInclude(td => td.Drug)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public IEnumerable<Mutation> GetMutations()
        {
            return _context.Mutations;
        }
    }
}