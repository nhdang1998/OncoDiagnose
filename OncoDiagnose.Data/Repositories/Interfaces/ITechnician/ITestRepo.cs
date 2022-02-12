using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models.Technician;
using System.Collections.Generic;
using System.Threading.Tasks;
using OncoDiagnose.Models;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces.ITechnician
{
    public interface ITestRepo : IGenericRepository<Test>
    {
        Task<IReadOnlyList<Test>> GetTestsAsync();

        Task<Test> GetTestByIdAsync(int id);

        IEnumerable<Result> GetResults();

        IEnumerable<Run> GetRuns();

        IEnumerable<Patient> GetPatients();

        Task<Result> GetResultById(int id);

        Task<List<Mutation>> GetMutations();
    }
}