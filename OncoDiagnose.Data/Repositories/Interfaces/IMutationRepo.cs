using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces
{
    public interface IMutationRepo : IGenericRepository<Mutation>
    {
        Task<IReadOnlyList<Mutation>> GetMutationsAsync();
        Task<Mutation> GetMutationByIdAsync(int id);
    }
}