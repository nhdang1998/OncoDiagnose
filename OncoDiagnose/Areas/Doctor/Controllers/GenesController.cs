using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OncoDiagnose.Web.Business;

namespace OncoDiagnose.Web.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class GenesController : Controller
    {
        private readonly GeneBusiness _geneBusiness;

        public GenesController(GeneBusiness geneBusiness)
        {
            _geneBusiness = geneBusiness;
        }

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
    }
}