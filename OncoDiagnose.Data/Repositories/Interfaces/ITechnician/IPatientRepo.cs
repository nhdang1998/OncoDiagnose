using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models.Technician;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces.ITechnician
{
    public interface IPatientRepo : IGenericRepository<Patient>
    {
        Task<IReadOnlyList<Patient>> GetPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
    }
}
