using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models.AuthenticateAndAuthorize;
using OncoDiagnose.Web.Utility;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly OncoDbContext _dbContext;

        public UserController(OncoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAll()
        {
            var users = await _dbContext.TechnicianAdminUsers.AsNoTracking().Include(ta => ta.Laboratory).ToListAsync();
            var userRole = _dbContext.UserRoles.ToList();
            var roles = _dbContext.Roles.ToList();
            foreach (var technicianAdminUser in users)
            {
                var roleId = userRole.FirstOrDefault(r => r.UserId == technicianAdminUser.Id)?.RoleId;
                technicianAdminUser.Role = roles.FirstOrDefault(r => r.Id.Equals(roleId))?.Name;
                technicianAdminUser.Laboratory ??= new Laboratory
                {
                    Name = ""
                };
            }
            return Json(new { data = users });
        }

        //[HttpDelete]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var objFromDb = await _unitOfWork.User.FindById(id);
        //    if (objFromDb == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting" });
        //    }
        //    _unitOfWork.
        //}

        [HttpPost]
        public async Task<IActionResult> LockUnlock([FromBody] string id)
        {
            var objFromDb = await _dbContext.TechnicianAdminUsers
                .Include(ta => ta.Laboratory)
                .AsNoTracking()
                .FirstOrDefaultAsync(ta => ta.Id.Equals(id));

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Locking/Unlocking" });
            }

            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //user is currently locked
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }

            _dbContext.Users.Attach(objFromDb);
            _dbContext.Entry(objFromDb).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return Json(new { success = true, message = "Operation success" });
        }
    }
}