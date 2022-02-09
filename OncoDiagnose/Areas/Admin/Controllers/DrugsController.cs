using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.ViewModels;
using OncoDiagnose.Web.ViewModels.DrugViewModels;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _drugBusiness.GetAll();
            return Json(new { data = allObj });
        }

        // GET: Admin/Drugs
        public IActionResult Index()
        {
            return View();
        }

        // GET: Admin/Drugs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drug = await _drugBusiness.GetById(id);
            if (drug == null)
            {
                return NotFound();
            }

            return View(drug);
        }

        // GET: Admin/Drugs/Create
        public IActionResult Create()
        {
            var synonyms = _drugBusiness.GetSynonyms();
            var selectList = synonyms.Select(synonym => new SelectListItem(synonym.SynonymInformation, synonym.Id.ToString())).ToList();

            var vm = new DrugCreateViewModel()
            {
                Synonyms = selectList
            };
            return View(vm);
        }

        // POST: Admin/Drugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DrugCreateViewModel drugViewModel)
        {
            try
            {
                var drugVM = new DrugViewModel()
                {
                    DrugName = drugViewModel.DrugName,
                    NcitCode = drugViewModel.NcitCode,
                    Priority = drugViewModel.Priority
                };
                
                foreach (var selectedSynonym in drugViewModel.SelectedSynonyms)
                {
                    drugVM.DrugSynonyms.Add(new DrugSynonymViewModel()
                    {
                        SynonymId = selectedSynonym
                    });
                }

                await _drugBusiness.Add(drugVM);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Drugs1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drug = await _drugBusiness.GetById(id);
            if (drug == null)
            {
                return NotFound();
            }

            var synonyms = _drugBusiness.GetSynonyms();
            var selectSynonyms = drug.DrugSynonyms.Select(x => new SynonymViewModel()
            {
                Id = x.Synonym.Id,
                SynonymInformation = x.Synonym.SynonymInformation
            });

            var selectList = new List<SelectListItem>();

            synonyms.ToList().ForEach(i => selectList.Add
                (new SelectListItem(i.SynonymInformation, i.Id.ToString(), selectSynonyms.Select(x => x.Id)
                    .Contains(i.Id)))); 

            // Truyen nhung Synonym dang duoc gan voi thuoc len tren view
            var selectedSynonymId = drug.DrugSynonyms.Select(ds => ds.SynonymId).ToArray();

            var vm = new DrugEditViewModel()
            {
                Id = drug.Id,
                DrugName = drug.DrugName,
                NcitCode = drug.NcitCode,
                Priority = drug.Priority,
                SelectedSynonyms = selectedSynonymId,
                Synonyms = selectList
            };
            
            return View(vm);
        }

        // POST: Admin/Drugs1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DrugEditViewModel drugEditViewModel)
        {
            if (id != drugEditViewModel.Id)
            {
                return NotFound();
            }

            switch (ModelState.IsValid)
            {
                case true:
                    try
                    {
                        var drugViewModel = new DrugViewModel()
                        {
                            Id = drugEditViewModel.Id,
                            NcitCode = drugEditViewModel.NcitCode,
                            DrugName = drugEditViewModel.DrugName,
                            Priority = drugEditViewModel.Priority
                        };
                        var selectedSynonyms = drugEditViewModel.SelectedSynonyms;
                        var existingSynonyms = drugViewModel.DrugSynonyms.Select(ds => ds.SynonymId).ToList();
                        var toAdd = selectedSynonyms.Except(existingSynonyms).ToList();
                        var toRemove = existingSynonyms.Except(selectedSynonyms).ToList();
                        drugViewModel.DrugSynonyms =
                            drugViewModel.DrugSynonyms.Where(x => !toRemove.Contains(x.SynonymId)).ToList();
                        foreach (var item in toAdd)
                        {
                            drugViewModel.DrugSynonyms.Add(new DrugSynonymViewModel
                            {
                                SynonymId = item,
                                DrugId = drugViewModel.Id
                            });
                        }

                        await _drugBusiness.Update(drugViewModel);
                        return RedirectToAction("Index", "Drugs");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!await DrugExists(drugEditViewModel.Id))
                        {
                            return NotFound();
                        }

                        throw;
                    }
                default:
                    return View(drugEditViewModel);
            }
        }

        // GET: Admin/Drugs1/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var objFromDb = await _drugBusiness.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _drugBusiness.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }

        private async Task<bool> DrugExists(int id)
        {
            var tmp = await _drugBusiness.GetAll();
            return tmp.Any(d => d.Id == id);
        }
    }
}
