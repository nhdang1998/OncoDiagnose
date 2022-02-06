using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess;
using OncoDiagnose.Models.Technician;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RunsController : Controller
    {
        private readonly OncoDbContext _context;

        public RunsController(OncoDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Runs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Runs.ToListAsync());
        }

        // GET: Admin/Runs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var run = await _context.Runs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (run == null)
            {
                return NotFound();
            }

            return View(run);
        }

        // GET: Admin/Runs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Runs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,FinishDate,TotalBase,KeySignal,TotalRead,UsableRead,MeanLength,MedianLength,ModeLength,ISPLoading,PolyClonal,LowQuality,Score,ISPLoadingPic,QualityPic,LengthPic")] Run run)
        {
            if (ModelState.IsValid)
            {
                _context.Add(run);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(run);
        }

        // GET: Admin/Runs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var run = await _context.Runs.FindAsync(id);
            if (run == null)
            {
                return NotFound();
            }
            return View(run);
        }

        // POST: Admin/Runs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,FinishDate,TotalBase,KeySignal,TotalRead,UsableRead,MeanLength,MedianLength,ModeLength,ISPLoading,PolyClonal,LowQuality,Score,ISPLoadingPic,QualityPic,LengthPic")] Run run)
        {
            if (id != run.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(run);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RunExists(run.Id))
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
            return View(run);
        }

        // GET: Admin/Runs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var run = await _context.Runs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (run == null)
            {
                return NotFound();
            }

            return View(run);
        }

        // POST: Admin/Runs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var run = await _context.Runs.FindAsync(id);
            _context.Runs.Remove(run);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RunExists(int id)
        {
            return _context.Runs.Any(e => e.Id == id);
        }
    }
}
