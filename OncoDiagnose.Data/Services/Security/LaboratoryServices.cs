using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces.ISecurity;
using OncoDiagnose.Models.AuthenticateAndAuthorize;

namespace OncoDiagnose.DataAccess.Services.Security
{
    public class LaboratoryServices : GenericRepository<Laboratory>, ILaboratoryRepo
    {
        public LaboratoryServices(OncoDbContext context) : base(context)
        {
        }
    }
}