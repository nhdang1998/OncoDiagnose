using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces
{
    public interface ITreatmentRepo : IGenericRepository<Treatment>
    {
        Task<IReadOnlyList<Treatment>> GetTreatmentsAsync();
        Task<Treatment> GetTreatmentByIdAsync(int id);
        IEnumerable<Mutation> GetMutations();
    }
}