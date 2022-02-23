using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces.ITechnician;
using OncoDiagnose.Models.Converter;
using OncoDiagnose.Models.Technician;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Services.Technician
{
    public class ResultServices : GenericRepository<Result>, IResultRepo
    {
        private readonly OncoDbContext _context;

        public ResultServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<string> GetGeneNameByResultId(int id)
        {
            var result = await GetByIdAsync(id);
            var geneName = result.GeneName;
            return geneName.GeneNameToString();
        }

        public async Task<IReadOnlyList<Result>> GetResultsAsync()
        {
            return await _context.Results
                .Include(r => r.Test)
                .ToListAsync();
        }

        public async Task<Result> GetResultByIdAsync(int id)
        {
            return await _context.Results
                .Include(r => r.Test)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public IEnumerable<Test> GetTests()
        {
            return _context.Tests;
        }
    }
}