using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models.Technician;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces.ITechnician
{
    public interface IRunRepo : IGenericRepository<Run>
    {
        Task<IReadOnlyList<Run>> GetRunsAsync();
        Task<Run> GetRunByIdAsync(int id);
    }
}
