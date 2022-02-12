using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.ViewModels;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResultsController : Controller
    {
        private readonly ResultBusiness _resultBusiness;

        public ResultsController(ResultBusiness resultBusiness)
        {
            _resultBusiness = resultBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _resultBusiness.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _resultBusiness.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _resultBusiness.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var resultViewModel = new ResultViewModel();
            if (id == null) return View(resultViewModel);
            resultViewModel = await _resultBusiness.GetById(id.GetValueOrDefault());
            if (resultViewModel == null) return NotFound();
            return View(resultViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ResultViewModel resultViewModel)
        {
            switch (ModelState.IsValid)
            {
                case true:
                    {
                        if (resultViewModel.Id == 0)
                        {
                            await _resultBusiness.Add(resultViewModel);
                        }
                        else
                        {
                            await _resultBusiness.Update(resultViewModel);
                        }
                        return RedirectToAction("Index");
                    }
                default:
                    return View(resultViewModel);
            }
        }
    }
}