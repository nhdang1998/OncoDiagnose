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
    public class CancerTypesController : Controller
    {
        private readonly CancerTypeBusiness _cancerType;

        public CancerTypesController(CancerTypeBusiness cancerType)
        {
            _cancerType = cancerType;
        }

        // GET: Admin/Aliases
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _cancerType.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _cancerType.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _cancerType.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var cancerTypeViewModel = new CancerTypeViewModel();

            if (id == null) return View(cancerTypeViewModel);
            cancerTypeViewModel = await _cancerType.GetById(id.GetValueOrDefault());
            if (cancerTypeViewModel == null) return NotFound();
            return View(cancerTypeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CancerTypeViewModel cancerTypeViewModel)
        {
            switch (ModelState.IsValid)
            {
                case true:
                {
                    if (cancerTypeViewModel.Id == 0)
                    {
                        await _cancerType.Add(cancerTypeViewModel);
                    }
                    else
                    {
                        await _cancerType.Update(cancerTypeViewModel);
                    }
                    return RedirectToAction("Index");
                }
                default:
                    return View(cancerTypeViewModel);
            }
        }
    }
}
