using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models.Technician;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces.ITechnician
{
    public interface ITestRepo : IGenericRepository<Test>
    {
        Task<List<string>> GetResultGeneNameByTestId(int id);
        Task<List<string>> GetResultVariantByTestId(int id);
        Task<List<double>> GetResultFrequenceByTestId(int id);
        Task<List<Result>> GetResultByTestId(int id);
        Task<IReadOnlyList<Test>> GetTestsAsync();
        Task<Test> GetTestByIdAsync(int id);
    }
}
