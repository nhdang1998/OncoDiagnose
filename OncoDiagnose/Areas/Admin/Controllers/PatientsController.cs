using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.Utility;
using OncoDiagnose.Web.ViewModels;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Database_Manager + "," + SD.Role_User_Laboratory)]
    public class PatientsController : Controller
    {
        private readonly PatientBusiness _patientBusiness;

        public PatientsController(PatientBusiness patientBusiness)
        {
            _patientBusiness = patientBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _patientBusiness.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _patientBusiness.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _patientBusiness.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var patientViewModel = new PatientViewModel();
            if (id == null) return View(patientViewModel);
            patientViewModel = await _patientBusiness.GetById(id.GetValueOrDefault());
            if (patientViewModel == null) return NotFound();
            return View(patientViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(PatientViewModel patientViewModel)
        {
            switch (ModelState.IsValid)
            {
                case true:
                    {
                        if (patientViewModel.Id == 0)
                        {
                            await _patientBusiness.Add(patientViewModel);
                        }
                        else
                        {
                            await _patientBusiness.Update(patientViewModel);
                        }
                        return RedirectToAction("Upsert", "Runs");
                    }
                default:
                    return View(patientViewModel);
            }
        }
    }
}