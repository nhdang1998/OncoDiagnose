using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces.ISecurity;
using OncoDiagnose.Models.AuthenticateAndAuthorize;

namespace OncoDiagnose.DataAccess.Services.Security
{
    public class UserServices : GenericRepository<TechnicianAdminUser>, IUserRepo
    {
        private readonly OncoDbContext _context;

        public UserServices(OncoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TechnicianAdminUser> FindById(string id)
        {
            return await _context.TechnicianAdminUsers
                .Include(ta => ta.Laboratory)
                .AsNoTracking()
                .FirstOrDefaultAsync(ta => ta.Id.Equals(id));
        }

        public async Task<List<TechnicianAdminUser>> FindAll()
        {
            return await _context.TechnicianAdminUsers
                .Include(ta => ta.Laboratory)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}