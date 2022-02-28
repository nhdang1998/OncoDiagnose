using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.Models.AuthenticateAndAuthorize;
using OncoDiagnose.Web.Utility;

namespace OncoDiagnose.DataAccess.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly OncoDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(OncoDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();
                }
                OncoDbInitializer.SeedCancerType(_db);
                OncoDbInitializer.SeedMutation(_db);
                OncoDbInitializer.SeedConsequence(_db);
                OncoDbInitializer.SeedGene(_db);
                OncoDbInitializer.SeedAlteration(_db);
                OncoDbInitializer.SeedArticle(_db);
                OncoDbInitializer.SeedTreatment(_db);
                OncoDbInitializer.SeedDrug(_db);
                OncoDbInitializer.SeedSynonym(_db);
                OncoDbInitializer.SeedDrugSynonym(_db);
                OncoDbInitializer.SeedAliase(_db);
                OncoDbInitializer.SeedGeneAliase(_db);
                OncoDbInitializer.SeedMutationArticle(_db);
                OncoDbInitializer.SeedTreatmentDrug(_db);

                OncoDbInitializer.SeedPatient(_db);
                OncoDbInitializer.SeedRun(_db);
                OncoDbInitializer.SeedTest(_db);
                OncoDbInitializer.SeedResult(_db);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (_db.Roles.Any(r => r.Name == SD.Role_Admin)) return;

            _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_Database_Manager)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_User)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Doctor)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Laboratory)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new TechnicianAdminUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                Name = "OncoDiagnose Admin"
            }, "Admin123*").GetAwaiter().GetResult();

            var user = _db.TechnicianAdminUsers
                .FirstOrDefault(u => u.Email == "admin@gmail.com");
            _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
        }
    }
}