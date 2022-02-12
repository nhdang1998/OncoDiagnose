using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.ViewModels;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RunsController : Controller
    {
        private readonly RunBusiness _runBusiness;

        public RunsController(RunBusiness runBusiness)
        {
            _runBusiness = runBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _runBusiness.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _runBusiness.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _runBusiness.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var runViewModel = new RunViewModel();
            if (id == null) return View(runViewModel);
            runViewModel = await _runBusiness.GetById(id.GetValueOrDefault());
            if (runViewModel == null) return NotFound();
            return View(runViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(RunViewModel runViewModel)
        {
            switch (ModelState.IsValid)
            {
                case true:
                    {
                        if (runViewModel.Id == 0)
                        {
                            await _runBusiness.Add(runViewModel);
                        }
                        else
                        {
                            await _runBusiness.Update(runViewModel);
                        }
                        return RedirectToAction("Index");
                    }
                default:
                    return View(runViewModel);
            }
        }
    }
}