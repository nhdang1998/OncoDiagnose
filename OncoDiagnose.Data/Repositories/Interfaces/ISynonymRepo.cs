using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces
{
    public interface ISynonymRepo : IGenericRepository<Synonym>
    {
        Task<IReadOnlyList<Synonym>> GetSynonymsAsync();
        Task<Synonym> GetSynonymByIdAsync(int id);
    }
}