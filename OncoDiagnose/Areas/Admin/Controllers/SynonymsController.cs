using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess;
using OncoDiagnose.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SynonymsController : Controller
    {
        private readonly OncoDbContext _context;

        public SynonymsController(OncoDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Synonyms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Synonyms.ToListAsync());
        }

        // GET: Admin/Synonyms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var synonym = await _context.Synonyms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (synonym == null)
            {
                return NotFound();
            }

            return View(synonym);
        }

        // GET: Admin/Synonyms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Synonyms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SynonymInformation")] Synonym synonym)
        {
            if (ModelState.IsValid)
            {
                _context.Add(synonym);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(synonym);
        }

        // GET: Admin/Synonyms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var synonym = await _context.Synonyms.FindAsync(id);
            if (synonym == null)
            {
                return NotFound();
            }
            return View(synonym);
        }

        // POST: Admin/Synonyms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SynonymInformation")] Synonym synonym)
        {
            if (id != synonym.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(synonym);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SynonymExists(synonym.Id))
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
            return View(synonym);
        }

        // GET: Admin/Synonyms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var synonym = await _context.Synonyms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (synonym == null)
            {
                return NotFound();
            }

            return View(synonym);
        }

        // POST: Admin/Synonyms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var synonym = await _context.Synonyms.FindAsync(id);
            _context.Synonyms.Remove(synonym);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SynonymExists(int id)
        {
            return _context.Synonyms.Any(e => e.Id == id);
        }
    }
}
