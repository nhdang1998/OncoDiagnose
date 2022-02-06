using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces
{
    public interface IAlterationRepo : IGenericRepository<Alteration>
    {
        Task<IReadOnlyList<Alteration>> GetAlterationsAsync();
        Task<Alteration> GetAlterationByIdAsync(int id);
        IEnumerable<Mutation> GetMutations();
        IEnumerable<Gene> GetGenes();
        IEnumerable<Consequence> GetConsequences();
    }
}