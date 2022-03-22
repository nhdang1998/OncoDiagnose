using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.Utility;
using OncoDiagnose.Web.ViewModels;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Database_Manager + "," + SD.Role_User_Laboratory)]
    public class ResultsController : Controller
    {
        private readonly ResultBusiness _resultBusiness;

        private readonly List<ResultViewModel> _result = new()
        {
            new ResultViewModel { GeneName = GeneNameViewModel.ABL1, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.AKT1, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.ALK, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.APC, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.ATM, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.BRAF, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.CDH1, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.CDKN2A, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.CSF1R, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.CTNNB1, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.EGFR, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.ERBB2, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.ERBB4, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.EZH2, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.FBXW7, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.FGFR1, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.FGFR2, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.FGFR3, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.FLT3, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.GNA11, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.GNAQ, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.GNAS, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.HER4, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.HNF1A, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.HRAS, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.IDH1, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.IDH2, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.JAK2, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.KDR, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.KIT, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.KRAS, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.MET, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.MLH1, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.MPL, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.NOTCH1, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.NPM1, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.NRAS, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.PDGFRA, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.PIK3CA, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.PTEN, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.PTPN11, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.RB1, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.RET, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.SMAD4, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.SMARCB1, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.SMO, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.SRC, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.STK11, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.TP53, Frequence = 0.0, Variant = "" },
            new ResultViewModel { GeneName = GeneNameViewModel.VHL, Frequence = 0.0, Variant = "" }
        };

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

        public IActionResult Create()
        {
            var tests = _resultBusiness.GetTestsTestViewModels().Where(t => t.Results.Count < 50);
            ViewBag.TestId = new SelectList(tests, "Id", "Id");
            return View(_result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<ResultViewModel> resultViewModels)
        {
            foreach (var resultViewModel in resultViewModels)
            {
                resultViewModel.Variant ??= "No mutation detected";
            }
            if (!ModelState.IsValid)
            {
                ModelState.Clear();
                return RedirectToAction("Details", "Tests", new { id = resultViewModels[0].TestId });
            }

            await _resultBusiness.AddRange(resultViewModels);
            ModelState.Clear();
            return RedirectToAction("Details", "Tests", new { id = resultViewModels[0].TestId });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultViewModel = await _resultBusiness.GetById(id);
            if (resultViewModel == null)
            {
                return NotFound();
            }
            ViewData["TestId"] = new SelectList(_resultBusiness.GetTestsTestViewModels(), "Id", "TestName", resultViewModel.TestId);
            return View(resultViewModel);
        }

        // POST: Admin/Drugs1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ResultViewModel resultViewModel)
        {
            if (id != resultViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _resultBusiness.Update(resultViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await ResultExists(resultViewModel.Id))
                    {
                        throw;
                    }

                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TestId"] = new SelectList(_resultBusiness.GetTestsTestViewModels(), "Id", "TestName", resultViewModel.TestId);
            return View(resultViewModel);
        }

        private async Task<bool> ResultExists(int id)
        {
            var tests = await _resultBusiness.GetAll();
            return tests.Any(r => r.Id == id);
        }
    }
}