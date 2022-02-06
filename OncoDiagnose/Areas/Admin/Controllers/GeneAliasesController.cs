using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess;
using OncoDiagnose.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GeneAliasesController : Controller
    {
        private readonly OncoDbContext _context;

        public GeneAliasesController(OncoDbContext context)
        {
            _context = context;
        }

        // GET: Admin/GeneAliases
        public async Task<IActionResult> Index()
        {
            var oncoDbContext = _context.GeneAliases.Include(g => g.Aliase).Include(g => g.Gene);
            return View(await oncoDbContext.ToListAsync());
        }

        // GET: Admin/GeneAliases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geneAliase = await _context.GeneAliases
                .Include(g => g.Aliase)
                .Include(g => g.Gene)
                .FirstOrDefaultAsync(m => m.GeneId == id);
            if (geneAliase == null)
            {
                return NotFound();
            }

            return Json(new { data = geneAliase });
            //return View(geneAliase);
        }

        // GET: Admin/GeneAliases/Create
        public IActionResult Create()
        {
            ViewData["AliaseId"] = new SelectList(_context.Aliases, "Id", "Id");
            ViewData["GeneId"] = new SelectList(_context.Genes, "Id", "Id");
            return View();
        }

        // POST: Admin/GeneAliases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GeneId,AliaseId")] GeneAliase geneAliase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(geneAliase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AliaseId"] = new SelectList(_context.Aliases, "Id", "Id", geneAliase.AliaseId);
            ViewData["GeneId"] = new SelectList(_context.Genes, "Id", "Id", geneAliase.GeneId);
            return View(geneAliase);
        }

        // GET: Admin/GeneAliases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geneAliase = await _context.GeneAliases.FindAsync(id);
            if (geneAliase == null)
            {
                return NotFound();
            }
            ViewData["AliaseId"] = new SelectList(_context.Aliases, "Id", "Id", geneAliase.AliaseId);
            ViewData["GeneId"] = new SelectList(_context.Genes, "Id", "Id", geneAliase.GeneId);
            return View(geneAliase);
        }

        // POST: Admin/GeneAliases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GeneId,AliaseId")] GeneAliase geneAliase)
        {
            if (id != geneAliase.GeneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(geneAliase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneAliaseExists(geneAliase.GeneId))
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
            ViewData["AliaseId"] = new SelectList(_context.Aliases, "Id", "Id", geneAliase.AliaseId);
            ViewData["GeneId"] = new SelectList(_context.Genes, "Id", "Id", geneAliase.GeneId);
            return View(geneAliase);
        }

        // GET: Admin/GeneAliases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geneAliase = await _context.GeneAliases
                .Include(g => g.Aliase)
                .Include(g => g.Gene)
                .FirstOrDefaultAsync(m => m.GeneId == id);
            if (geneAliase == null)
            {
                return NotFound();
            }

            return View(geneAliase);
        }

        // POST: Admin/GeneAliases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var geneAliase = await _context.GeneAliases.FindAsync(id);
            _context.GeneAliases.Remove(geneAliase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneAliaseExists(int? id)
        {
            return _context.GeneAliases.Any(e => e.GeneId == id);
        }
    }
}
