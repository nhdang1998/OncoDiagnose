using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces
{
    public interface IGeneRepo : IGenericRepository<Gene>
    {
        Task<IReadOnlyList<Gene>> GetGenesAsync();
        Task<Gene> GetGeneByIdAsync(int id);
        IEnumerable<Aliase> GetAliases();
    }
}