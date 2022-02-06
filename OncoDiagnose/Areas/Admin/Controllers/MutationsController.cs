using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess;
using OncoDiagnose.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MutationsController : Controller
    {
        private readonly OncoDbContext _context;

        public MutationsController(OncoDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Mutations
        public async Task<IActionResult> Index()
        {
            var mutations = await _context.Mutations.ToListAsync();
            return Json(new { data = mutations });
            //return View();
        }

        // GET: Admin/Mutations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mutation = await _context.Mutations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mutation == null)
            {
                return NotFound();
            }

            return View(mutation);
        }

        // GET: Admin/Mutations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Mutations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EvidenceType,Desciption,AdditionalInfor,KnownEffect,LastEdit,LastReview,LevelOfEvidence,SolidPropagationLevel,LiquidPropagationLevel")] Mutation mutation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mutation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mutation);
        }

        // GET: Admin/Mutations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mutation = await _context.Mutations.FindAsync(id);
            if (mutation == null)
            {
                return NotFound();
            }
            return View(mutation);
        }

        // POST: Admin/Mutations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EvidenceType,Desciption,AdditionalInfor,KnownEffect,LastEdit,LastReview,LevelOfEvidence,SolidPropagationLevel,LiquidPropagationLevel")] Mutation mutation)
        {
            if (id != mutation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mutation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MutationExists(mutation.Id))
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
            return View(mutation);
        }

        // GET: Admin/Mutations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mutation = await _context.Mutations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mutation == null)
            {
                return NotFound();
            }

            return View(mutation);
        }

        // POST: Admin/Mutations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mutation = await _context.Mutations.FindAsync(id);
            _context.Mutations.Remove(mutation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MutationExists(int id)
        {
            return _context.Mutations.Any(e => e.Id == id);
        }
    }
}
