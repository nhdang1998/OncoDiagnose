using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess;
using OncoDiagnose.Models;
using System.Linq;
using System.Threading.Tasks;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.ViewModels;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DrugsController : Controller
    {
        private readonly DrugBusiness _drugBusiness;

        public DrugsController(DrugBusiness drugBusiness)
        {
            _drugBusiness = drugBusiness;
        }

        // GET: Admin/Aliases
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _drugBusiness.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _drugBusiness.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _drugBusiness.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var drugViewModel = new DrugViewModel();

            if (id == null) return View(drugViewModel);
            drugViewModel = await _drugBusiness.GetById(id.GetValueOrDefault());
            if (drugViewModel == null) return NotFound();
            return View(drugViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(DrugViewModel drugViewModel)
        {
            switch (ModelState.IsValid)
            {
                case true:
                {
                    if (drugViewModel.Id == 0)
                    {
                        await _drugBusiness.Add(drugViewModel);
                    }
                    else
                    {
                        await _drugBusiness.Update(drugViewModel);
                    }
                    return RedirectToAction("Index");
                }
                default:
                    return View(drugViewModel);
            }
        }
    }
}
