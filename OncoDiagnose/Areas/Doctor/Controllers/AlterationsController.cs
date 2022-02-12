using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.ViewModels;

namespace OncoDiagnose.Web.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class AlterationsController : Controller
    {
        private readonly AlterationBusiness _alterationBusiness;

        public AlterationsController(AlterationBusiness alterationBusiness)
        {
            _alterationBusiness = alterationBusiness;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geneViewModel = await _alterationBusiness.GetById(id.GetValueOrDefault());
            if (geneViewModel == null)
            {
                return NotFound();
            }

            return View(geneViewModel);
        }
    }
}