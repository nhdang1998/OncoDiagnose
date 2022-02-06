using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces.ITechnician;
using OncoDiagnose.Models.Technician;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Services.Technician
{
    public class PatientServices : GenericRepository<Patient>, IPatientRepo
    {
        private readonly OncoDbContext _context;

        public PatientServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Patient>> GetPatientsAsync()
        {
            return await _context.Patients
                .Include(p => p.Tests)
                .ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _context.Patients
                .Include(p => p.Tests)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
