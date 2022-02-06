using Microsoft.AspNetCore.Mvc;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.ViewModels;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AliasesController : Controller
    {
        private readonly AliaseBusiness _aliasesBusiness;

        public AliasesController(AliaseBusiness aliasesBusiness)
        {
            _aliasesBusiness = aliasesBusiness;
        }

        // GET: Admin/Aliases
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _aliasesBusiness.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _aliasesBusiness.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _aliasesBusiness.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }


        public async Task<IActionResult> Upsert(int? id)
        {
            var aliase = new AliaseViewModel();
            if (id == null) return View(aliase);
            aliase = await _aliasesBusiness.GetById(id.GetValueOrDefault());
            if (aliase == null) return NotFound();
            return View(aliase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(AliaseViewModel aliase)
        {
            switch (ModelState.IsValid)
            {
                case true:
                    {
                        if (aliase.Id == 0)
                        {
                            await _aliasesBusiness.Add(aliase);
                        }
                        else
                        {
                            await _aliasesBusiness.Update(aliase);
                        }
                        return RedirectToAction("Index");
                    }
                default:
                    return View(aliase);
            }
        }
    }
}
