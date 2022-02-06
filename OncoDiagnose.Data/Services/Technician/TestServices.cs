using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces.ITechnician;
using OncoDiagnose.Models.Converter;
using OncoDiagnose.Models.Technician;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Services.Technician
{
    public class TestServices : GenericRepository<Test>, ITestRepo
    {
        private readonly OncoDbContext _context;

        public TestServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<string>> GetResultGeneNameByTestId(int id)
        {
            var test = await GetByIdAsync(id);
            return test.Results.Select(result => result.GeneName)
                .Select(Converter.GeneNameToString)
                .ToList();
        }

        public async Task<List<string>> GetResultVariantByTestId(int id)
        {
            var test = await GetByIdAsync(id);
            return test.Results.Select(result => result.Variant).ToList();
        }

        public async Task<List<double>> GetResultFrequenceByTestId(int id)
        {
            var test = await GetByIdAsync(id);
            return test.Results.Select(result => result.Frequence).ToList();
        }

        public async Task<List<Result>> GetResultByTestId(int id)
        {
            var test = await GetByIdAsync(id);
            return test.Results;
        }

        public async Task<IReadOnlyList<Test>> GetTestsAsync()
        {
            return await _context.Tests
                .Include(t => t.Run)
                .Include(t => t.Results)
                .Include(t => t.Patient)
                .Include(t => t.Results)
                .ToListAsync();
        }

        public async Task<Test> GetTestByIdAsync(int id)
        {
            return await _context.Tests
                .Include(t => t.Run)
                .Include(t => t.Results)
                .Include(t => t.Patient)
                .Include(t => t.Results)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
