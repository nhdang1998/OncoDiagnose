using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces.ITechnician;
using OncoDiagnose.Models.Technician;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Services.Technician
{
    public class RunServices : GenericRepository<Run>, IRunRepo
    {
        private readonly OncoDbContext _context;

        public RunServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Run>> GetRunsAsync()
        {
            return await _context.Runs
                .Include(r => r.Test)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Run> GetRunByIdAsync(int id)
        {
            return await _context.Runs
                .Include(r => r.Test)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}