using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.Utility;
using OncoDiagnose.Web.ViewModels;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Database_Manager + "," + SD.Role_User_Laboratory)]
    public class TestsController : Controller
    {
        private readonly TestBusiness _testBusiness;

        public TestsController(TestBusiness testBusiness)
        {
            _testBusiness = testBusiness;
        }

        // GET: Admin/Aliases
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _testBusiness.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _testBusiness.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _testBusiness.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testViewModel = await _testBusiness.GetById(id);

            if (testViewModel == null)
            {
                return NotFound();
            }

            var testDetailView = new TestDetailViewModel
            {
                Id = testViewModel.Id,
                TestDate = testViewModel.TestDate,
                TestName = testViewModel.TestName,
                PatientId = testViewModel.PatientId,
                Patient = testViewModel.Patient,
                RunId = testViewModel.RunId,
                Run = testViewModel.Run,
                Results = testViewModel.Results,
                Mutations = await _testBusiness.GetMutations()
            };

            return View(testDetailView);
        }

        // GET: Admin/Drugs/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_testBusiness.GetPatients(), "Id", "Name");
            ViewData["RunId"] = new SelectList(_testBusiness.GetRuns(), "Id", "Id");

            return View();
        }

        // POST: Admin/Drugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TestViewModel testView)
        {
            if (ModelState.IsValid)
            {
                await _testBusiness.Add(testView);
                return RedirectToAction("Create", "Results");
            }
            ViewData["PatientId"] = new SelectList(_testBusiness.GetPatients(), "Id", "Name", testView.PatientId);
            ViewData["RunId"] = new SelectList(_testBusiness.GetRuns(), "Id", "Id", testView.RunId);
            return RedirectToAction("Create", "Results");
        }

        // GET: Admin/Drugs1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _testBusiness.GetById(id);
            if (test == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_testBusiness.GetPatients(), "Id", "Id", test.PatientId);
            ViewData["RunId"] = new SelectList(_testBusiness.GetRuns(), "Id", "Id", test.RunId);
            return View(test);
        }

        // POST: Admin/Drugs1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TestViewModel test)
        {
            if (id != test.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _testBusiness.Update(test);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await TestExists(test.Id))
                    {
                        throw;
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_testBusiness.GetPatients(), "Id", "Id", test.PatientId);
            ViewData["RunId"] = new SelectList(_testBusiness.GetRuns(), "Id", "Id", test.RunId);
            return View(test);
        }

        private async Task<bool> TestExists(int id)
        {
            var tests = await _testBusiness.GetAll();
            return tests.Any(e => e.Id == id);
        }
    }
}