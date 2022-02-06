using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces;
using OncoDiagnose.Models;

namespace OncoDiagnose.DataAccess.Services
{
    public class GeneAliaseServices : GenericRepository<GeneAliase>, IGeneAliaseRepo
    {
        private readonly OncoDbContext _context;

        public GeneAliaseServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }
    }
}