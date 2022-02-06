using System.Collections.Generic;
using System.Threading.Tasks;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces
{
    public interface IDrugSynonymRepo : IGenericRepository<DrugSynonym>
    {
        Task<List<DrugSynonym>> GetDrugSynonymsAsync();
        Task<DrugSynonym> GetDrugSynonymAsync(int drugId, int synonymId);
        IEnumerable<Drug> GetDrugs();
        IEnumerable<Synonym> GetSynonyms();
    }
}