using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.Utility;
using OncoDiagnose.Web.ViewModels;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Database_Manager)]
    public class ConsequencesController : Controller
    {
        private readonly ConsequenceBusiness _consequenceBusiness;

        public ConsequencesController(ConsequenceBusiness consequenceBusiness)
        {
            _consequenceBusiness = consequenceBusiness;
        }

        // GET: Admin/Aliases
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _consequenceBusiness.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _consequenceBusiness.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _consequenceBusiness.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var consequenceViewModel = new ConsequenceViewModel();
            if (id == null) return View(consequenceViewModel);
            consequenceViewModel = await _consequenceBusiness.GetById(id.GetValueOrDefault());
            if (consequenceViewModel == null) return NotFound();
            return View(consequenceViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ConsequenceViewModel consequenceViewModel)
        {
            switch (ModelState.IsValid)
            {
                case true:
                    {
                        if (consequenceViewModel.Id == 0)
                        {
                            await _consequenceBusiness.Add(consequenceViewModel);
                        }
                        else
                        {
                            await _consequenceBusiness.Update(consequenceViewModel);
                        }
                        return RedirectToAction("Index");
                    }
                default:
                    return View(consequenceViewModel);
            }
        }
    }
}