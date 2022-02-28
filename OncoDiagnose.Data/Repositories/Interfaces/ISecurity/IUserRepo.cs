using System.Collections.Generic;
using System.Threading.Tasks;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models.AuthenticateAndAuthorize;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces.ISecurity
{
    public interface IUserRepo : IGenericRepository<TechnicianAdminUser>
    {
        Task<TechnicianAdminUser> FindById(string id);

        Task<List<TechnicianAdminUser>> FindAll();
    }
}