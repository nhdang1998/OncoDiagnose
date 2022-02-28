using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.Utility;
using OncoDiagnose.Web.ViewModels;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Database_Manager)]
    public class MutationsController : Controller
    {
        private readonly MutationBusiness _mutationBusiness;

        public MutationsController(MutationBusiness mutationBusiness)
        {
            _mutationBusiness = mutationBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _mutationBusiness.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _mutationBusiness.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _mutationBusiness.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var mutationViewModel = new MutationViewModel();
            ViewData["CancerTypeId"] = new SelectList(_mutationBusiness.GetCancerTypeViewModels(), "Id", "MainType", mutationViewModel.CancerTypeId);
            if (id == null) return View(mutationViewModel);
            mutationViewModel = await _mutationBusiness.GetById(id.GetValueOrDefault());
            if (mutationViewModel == null) return NotFound();
            return View(mutationViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(MutationViewModel mutationViewModel)
        {
            switch (ModelState.IsValid)
            {
                case true:
                    {
                        if (mutationViewModel.Id == 0)
                        {
                            await _mutationBusiness.Add(mutationViewModel);
                        }
                        else
                        {
                            await _mutationBusiness.Update(mutationViewModel);
                        }
                        return RedirectToAction("Index");
                    }
                default:
                    return View(mutationViewModel);
            }
        }
    }
}