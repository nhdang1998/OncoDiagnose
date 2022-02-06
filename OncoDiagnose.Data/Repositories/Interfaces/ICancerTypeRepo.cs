using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces
{
    public interface ICancerTypeRepo : IGenericRepository<CancerType>
    {
        Task<IReadOnlyList<CancerType>> GetCancerTypesAsync();
        Task<CancerType> GetCancerTypeByIdAsync(int id);
        IEnumerable<Mutation> GetMutations();
    }
}