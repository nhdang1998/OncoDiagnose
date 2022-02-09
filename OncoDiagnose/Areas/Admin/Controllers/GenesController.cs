using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess;
using OncoDiagnose.Web.Business;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using OncoDiagnose.Web.ViewModels;
using OncoDiagnose.Web.ViewModels.GeneViewModels;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenesController : Controller
    {
        private readonly GeneBusiness _geneBusiness;

        public GenesController(GeneBusiness geneBusiness)
        {
            _geneBusiness = geneBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _geneBusiness.GetAll();
            return Json(new { data = allObj });
        }

        // GET: Admin/Genes
        public IActionResult Index()
        {
            return View();
        }

        // GET: Admin/Genes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geneViewModel = await _geneBusiness.GetById(id);
            if (geneViewModel == null)
            {
                return NotFound();
            }

            return View(geneViewModel);
        }

        // GET: Admin/Genes/Create
        public IActionResult Create()
        {
            var aliases = _geneBusiness.GetAliases();
            var selectList = aliases.Select(synonym => new SelectListItem(synonym.Name, synonym.Id.ToString())).ToList();

            var vm = new GeneCreateViewModel()
            {
                Aliases = selectList
            };
            return View(vm);
        }

        // POST: Admin/Genes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GeneCreateViewModel geneCreateViewModel)
        {
            try
            {
                var geneVM = new GeneViewModel()
                {
                    HugoSymbol = geneCreateViewModel.HugoSymbol,
                    OncoGene = geneCreateViewModel.OncoGene,
                    Grch37Isoform = geneCreateViewModel.Grch37Isoform,
                    Grch37RefSeq = geneCreateViewModel.Grch37RefSeq,
                    Grch38Isoform = geneCreateViewModel.Grch38Isoform,
                    Grch38RefSeq = geneCreateViewModel.Grch38RefSeq,
                    Tsg = geneCreateViewModel.Tsg
                };

                foreach (var selectedAlias in geneCreateViewModel.SelectedAliases)
                {
                    geneVM.GeneAliases.Add(new GeneAliaseViewModel
                    {
                        AliaseId = selectedAlias
                    });
                }

                await _geneBusiness.Add(geneVM);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // GET: Admin/Genes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gene = await _geneBusiness.GetById(id);
            if (gene == null)
            {
                return NotFound();
            }

            var aliases = _geneBusiness.GetAliases();
            var selectedAliases = gene.GeneAliases.Select(ga => new AliaseViewModel
            {
                Id = ga.AliaseId,
                Name = ga.Aliase.Name
            });

            var selectList = new List<SelectListItem>();

            aliases.ToList().ForEach(a => selectList.Add(new SelectListItem(a.Name, a.Id.ToString(), selectedAliases.Select(a => a.Id).Contains(a.Id))));
            var selectedAliaseId = gene.GeneAliases.Select(ga => ga.Aliase.Id).ToArray();

            var vm = new GeneEditViewModel
            {
                Id = gene.Id,
                HugoSymbol = gene.HugoSymbol,
                OncoGene = gene.OncoGene,
                Grch37Isoform = gene.Grch37Isoform,
                Grch37RefSeq = gene.Grch37RefSeq,
                Grch38Isoform = gene.Grch38Isoform,
                Grch38RefSeq = gene.Grch38RefSeq,
                Tsg = gene.Tsg,
                SelectedAliases = selectedAliaseId,
                Aliases = selectList
            };
            return View(vm);
        }

        // POST: Admin/Genes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GeneEditViewModel geneEditViewModel)
        {
            if (id != geneEditViewModel.Id)
            {
                return NotFound();
            }

            switch (ModelState.IsValid)
            {
                case true:
                    try
                    {
                        var geneViewModel = new GeneViewModel
                        {
                            Id = geneEditViewModel.Id,
                            HugoSymbol = geneEditViewModel.HugoSymbol,
                            OncoGene = geneEditViewModel.OncoGene,
                            Grch37Isoform = geneEditViewModel.Grch37Isoform,
                            Grch37RefSeq = geneEditViewModel.Grch37RefSeq,
                            Grch38Isoform = geneEditViewModel.Grch38Isoform,
                            Grch38RefSeq = geneEditViewModel.Grch38RefSeq,
                            Tsg = geneEditViewModel.Tsg
                        };

                        var selectedAliases = geneEditViewModel.SelectedAliases;
                        var existingAliases = geneViewModel.GeneAliases.Select(ga => ga.AliaseId).ToList();
                        var toAdd = selectedAliases.Except(existingAliases.ToList());
                        var toRemove = existingAliases.Except(selectedAliases).ToList();

                        geneViewModel.GeneAliases = geneViewModel.GeneAliases
                            .Where(ga => !toRemove.Contains(ga.AliaseId)).ToList();

                        foreach (var item in toAdd)
                        {
                            geneViewModel.GeneAliases.Add(new GeneAliaseViewModel
                            {
                                AliaseId = item,
                                GeneId = geneViewModel.Id
                            });
                        }

                        await _geneBusiness.Update(geneViewModel);
                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!await GeneExists(geneEditViewModel.Id))
                        {
                            return NotFound();
                        }

                        throw;
                    }
                default:
                    return View(geneEditViewModel);
            }
        }

        // GET: Admin/Genes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objFromDb = await _geneBusiness.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _geneBusiness.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }


        private async Task<bool> GeneExists(int id)
        {
            var tmp = await _geneBusiness.GetAll();
            return tmp.Any(d => d.Id == id);
        }
    }
}
