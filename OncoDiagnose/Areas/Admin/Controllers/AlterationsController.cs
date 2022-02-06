using Microsoft.AspNetCore.Mvc;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AlterationsController : Controller
    {
        private readonly AlterationBusiness _alterationBusiness;

        public AlterationsController(AlterationBusiness alterationBusiness)
        {
            _alterationBusiness = alterationBusiness;
        }

        // GET: Admin/Aliases
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _alterationBusiness.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _alterationBusiness.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _alterationBusiness.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var alteration = new AlterationViewModel();
            ViewData["MutationId"] = new SelectList(_alterationBusiness.GetMutations(), "Id", "Id", alteration.MutationId);
            ViewData["GeneId"] = new SelectList(_alterationBusiness.GetGenes(), "Id", "HugoSymbol", alteration.GeneId);
            ViewData["ConsequenceId"] = new SelectList(_alterationBusiness.GetConsequences(), "Id", "Description", alteration.ConsequenceId);
            
            if (id == null) return View(alteration);
            alteration = await _alterationBusiness.GetById(id.GetValueOrDefault());
            if (alteration == null) return NotFound();
            return View(alteration);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(AlterationViewModel alterationViewModel)
        {
            switch (ModelState.IsValid)
            {
                case true:
                    {
                        if (alterationViewModel.Id == 0)
                        {
                            await _alterationBusiness.Add(alterationViewModel);
                        }
                        else
                        {
                            await _alterationBusiness.Update(alterationViewModel);
                        }
                        return RedirectToAction("Index");
                    }
                default:
                    return View(alterationViewModel);
            }
        }
    }
}
