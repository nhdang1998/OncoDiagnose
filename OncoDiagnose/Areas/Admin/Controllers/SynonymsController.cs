using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.Utility;
using OncoDiagnose.Web.ViewModels;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Database_Manager)]
    public class SynonymsController : Controller
    {
        private readonly SynonymBusiness _synonymBusiness;

        public SynonymsController(SynonymBusiness synonymBusiness)
        {
            _synonymBusiness = synonymBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _synonymBusiness.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _synonymBusiness.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _synonymBusiness.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var synonymViewModel = new SynonymViewModel();
            if (id == null) return View(synonymViewModel);
            synonymViewModel = await _synonymBusiness.GetById(id.GetValueOrDefault());
            if (synonymViewModel == null) return NotFound();
            return View(synonymViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(SynonymViewModel synonymViewModel)
        {
            switch (ModelState.IsValid)
            {
                case true:
                    {
                        if (synonymViewModel.Id == 0)
                        {
                            await _synonymBusiness.Add(synonymViewModel);
                        }
                        else
                        {
                            await _synonymBusiness.Update(synonymViewModel);
                        }
                        return RedirectToAction("Index");
                    }
                default:
                    return View(synonymViewModel);
            }
        }
    }
}