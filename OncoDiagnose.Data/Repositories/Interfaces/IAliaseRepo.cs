using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces
{
    public interface IAliaseRepo : IGenericRepository<Aliase>
    {
        Task<IReadOnlyList<Aliase>> GetAliasesAsync();
        Task<Aliase> GetAliaseByIdAsync(int id);
    }
}