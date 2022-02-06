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
    public class DrugSynonymsController : Controller
    {
        private readonly DrugSynonymBusiness _drugSynonymBusiness;

        public DrugSynonymsController(DrugSynonymBusiness drugSynonymBusiness)
        {
            _drugSynonymBusiness = drugSynonymBusiness;
        }

        // GET: Admin/Aliases
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _drugSynonymBusiness.GetAll();
            return Json(new { data = allObj });
        }

        public async Task<IActionResult> Upsert(int? drugId, int? synonymId)
        {
            var drugSynonymViewModel = new DrugSynonymViewModel();

            ViewBag.Synonyms = _drugSynonymBusiness.GetSynonyms();
            ViewBag.DrugId = new SelectList(_drugSynonymBusiness.GetDrugs(), "Id", "DrugName");

            if (drugId == null && synonymId == null) return View(drugSynonymViewModel);
            drugSynonymViewModel = await _drugSynonymBusiness.GetById(drugId.GetValueOrDefault(), synonymId.GetValueOrDefault());
            if (drugSynonymViewModel == null) return NotFound();
            return View(drugSynonymViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(DrugSynonymViewModel drugSynonymViewModel)
        {
            switch (ModelState.IsValid)
            {
                case true:
                {
                    if (drugSynonymViewModel.DrugId == 0 && drugSynonymViewModel.SynonymId == 0)
                    {
                        await _drugSynonymBusiness.Add(drugSynonymViewModel);
                    }
                    else
                    {
                        await _drugSynonymBusiness.Update(drugSynonymViewModel);
                    }
                    return RedirectToAction("Index");
                }
                default:
                    return View(drugSynonymViewModel);
            }
        }
    }
}
