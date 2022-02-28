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
    public class ArticlesController : Controller
    {
        private readonly ArticleBusiness _articleBusiness;

        public ArticlesController(ArticleBusiness articleBusiness)
        {
            _articleBusiness = articleBusiness;
        }

        // GET: Admin/Aliases
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _articleBusiness.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _articleBusiness.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _articleBusiness.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var articleViewModel = new ArticleViewModel();

            if (id == null) return View(articleViewModel);
            articleViewModel = await _articleBusiness.GetById(id.GetValueOrDefault());
            if (articleViewModel == null) return NotFound();
            return View(articleViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ArticleViewModel articleViewModel)
        {
            switch (ModelState.IsValid)
            {
                case true:
                    {
                        if (articleViewModel.Id == 0)
                        {
                            await _articleBusiness.Add(articleViewModel);
                        }
                        else
                        {
                            await _articleBusiness.Update(articleViewModel);
                        }
                        return RedirectToAction("Index");
                    }
                default:
                    return View(articleViewModel);
            }
        }
    }
}