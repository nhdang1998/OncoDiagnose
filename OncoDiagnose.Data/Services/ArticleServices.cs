using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces;
using OncoDiagnose.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Services
{
    public class ArticleServices : GenericRepository<Article>, IArticleRepo
    {
        private readonly OncoDbContext _context;

        public ArticleServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Article>> GetArticlesAsync()
        {
            return await _context.Articles
                .Include(a => a.MutationArticles)
                .ThenInclude(ma => ma.Mutation)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Article> GetArticleByIdAsync(int id)
        {
            return await _context.Articles
                .AsNoTracking()
                .Include(a => a.MutationArticles)
                .ThenInclude(ma => ma.Mutation)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public IEnumerable<Mutation> GetMutations()
        {
            return _context.Mutations;
        }
    }
}