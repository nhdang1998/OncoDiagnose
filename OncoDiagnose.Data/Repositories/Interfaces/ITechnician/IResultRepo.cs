using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models.Technician;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces.ITechnician
{
    public interface IResultRepo : IGenericRepository<Result>
    {
        Task<string> GetGeneNameByResultId(int id);

        Task<IReadOnlyList<Result>> GetResultsAsync();

        Task<Result> GetResultByIdAsync(int id);

        IEnumerable<Test> GetTests();
    }
}