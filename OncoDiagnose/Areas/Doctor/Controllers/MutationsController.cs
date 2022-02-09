using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OncoDiagnose.Web.Business;

namespace OncoDiagnose.Web.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class MutationsController : Controller
    {
        private readonly MutationBusiness _mutationBusiness;

        public MutationsController(MutationBusiness mutationBusiness)
        {
            _mutationBusiness = mutationBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _mutationBusiness.GetAll();
            return Json(new { data = allObj });
        }

        // GET: Doctor/Mutations
        public IActionResult Index()
        {
            return View();
        }

        // GET: Doctor/Mutations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mutation = await _mutationBusiness.GetById(id);

            if(mutation == null)
            {
                return NotFound();
            }

            return View(mutation);
        }
    }
}
