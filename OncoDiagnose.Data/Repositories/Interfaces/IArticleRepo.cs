using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces
{
    public interface IArticleRepo : IGenericRepository<Article>
    {
        Task<IReadOnlyList<Article>> GetArticlesAsync();
        Task<Article> GetArticleByIdAsync(int id);
        IEnumerable<Mutation> GetMutations();
    }
}