using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess;
using OncoDiagnose.Models;
using OncoDiagnose.Web.Business;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenesController : Controller
    {
        private readonly OncoDbContext _context;
        private readonly GeneBusiness _geneBusiness;


        public GenesController(OncoDbContext context, GeneBusiness geneBusiness)
        {
            _context = context;
            _geneBusiness = geneBusiness;
        }

        // GET: Admin/Genes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Genes.ToListAsync());
        }

        // GET: Admin/Genes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var response = await _geneBusiness.GetById(id);

            return Json(new { data = response });
            //return View(gene);
        }

        // GET: Admin/Genes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Genes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HugoSymbol,OncoGene,Grch37Isoform,Grch37RefSeq,Grch38Isoform,Grch38RefSeq,Tsg")] Gene gene)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gene);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gene);
        }

        // GET: Admin/Genes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gene = await _context.Genes.FindAsync(id);
            if (gene == null)
            {
                return NotFound();
            }
            return View(gene);
        }

        // POST: Admin/Genes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HugoSymbol,OncoGene,Grch37Isoform,Grch37RefSeq,Grch38Isoform,Grch38RefSeq,Tsg")] Gene gene)
        {
            if (id != gene.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gene);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneExists(gene.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gene);
        }

        // GET: Admin/Genes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gene = await _context.Genes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gene == null)
            {
                return NotFound();
            }

            return View(gene);
        }

        // POST: Admin/Genes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gene = await _context.Genes.FindAsync(id);
            _context.Genes.Remove(gene);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneExists(int id)
        {
            return _context.Genes.Any(e => e.Id == id);
        }
    }
}
