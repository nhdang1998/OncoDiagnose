using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.Utility;
using OncoDiagnose.Web.ViewModels;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Database_Manager)]
    public class TreatmentsController : Controller
    {
        private readonly TreatmentBusiness _treatmentBusiness;

        public TreatmentsController(TreatmentBusiness treatmentBusiness)
        {
            _treatmentBusiness = treatmentBusiness;
        }

        // GET: Admin/Treatments
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _treatmentBusiness.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _treatmentBusiness.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _treatmentBusiness.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var treatmentViewModel = new TreatmentViewModel();
            ViewData["MutationId"] = new SelectList(_treatmentBusiness.GetMutations(), "Id", "Id", treatmentViewModel.MutationId);

            if (id == null) return View(treatmentViewModel);
            treatmentViewModel = await _treatmentBusiness.GetById(id.GetValueOrDefault());
            if (treatmentViewModel == null) return NotFound();
            return View(treatmentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(TreatmentViewModel treatmentViewModel)
        {
            switch (ModelState.IsValid)
            {
                case true:
                    {
                        if (treatmentViewModel.Id == 0)
                        {
                            await _treatmentBusiness.Add(treatmentViewModel);
                        }
                        else
                        {
                            await _treatmentBusiness.Update(treatmentViewModel);
                        }
                        return RedirectToAction("Index");
                    }
                default:
                    return View(treatmentViewModel);
            }
        }
    }
}