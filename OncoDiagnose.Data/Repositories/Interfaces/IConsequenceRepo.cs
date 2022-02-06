using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces
{
    public interface IConsequenceRepo : IGenericRepository<Consequence>
    {
        Task<IReadOnlyList<Consequence>> GetConsequencesAsync();
        Task<Consequence> GetConsequenceByIdAsync(int id);
    }
}