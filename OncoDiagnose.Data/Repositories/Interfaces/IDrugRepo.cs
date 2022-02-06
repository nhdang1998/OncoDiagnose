using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces
{
    public interface IDrugRepo : IGenericRepository<Drug>
    {
        Task<IReadOnlyList<Drug>> GetDrugsAsync();
        Task<Drug> GetDrugByIdAsync(int id);
        IEnumerable<Treatment> GetTreatments();
        IEnumerable<Synonym> GetSynonyms();
    }
}