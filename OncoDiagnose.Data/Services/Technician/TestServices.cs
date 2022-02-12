using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces.ITechnician;
using OncoDiagnose.Models.Technician;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OncoDiagnose.Models;

namespace OncoDiagnose.DataAccess.Services.Technician
{
    public class TestServices : GenericRepository<Test>, ITestRepo
    {
        private readonly OncoDbContext _context;

        public TestServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Mutation>> GetMutations()
        {
            return await _context.Mutations
                .Include(m => m.CancerType)
                .Include(m => m.MutationArticles)
                .ThenInclude(ma => ma.Article)
                .Include(m => m.Alterations)
                .ThenInclude(a => a.Gene)
                .Include(m => m.Treatments)
                .ThenInclude(t => t.TreatmentDrugs)
                .ThenInclude(td => td.Drug)
                .AsNoTracking()
                .ToListAsync();
        }

        public IEnumerable<Result> GetResults()
        {
            return _context.Results;
        }

        public async Task<Result> GetResultById(int id)
        {
            return await _context.Results.FirstOrDefaultAsync(r => r.Id == id);
        }

        public IEnumerable<Run> GetRuns()
        {
            return _context.Runs;
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _context.Patients;
        }

        public async Task<IReadOnlyList<Test>> GetTestsAsync()
        {
            return await _context.Tests
                .Include(t => t.Run)
                .Include(t => t.Results)
                .Include(t => t.Patient)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Test> GetTestByIdAsync(int id)
        {
            return await _context.Tests
                .Include(t => t.Run)
                .Include(t => t.Results)
                .Include(t => t.Patient)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}