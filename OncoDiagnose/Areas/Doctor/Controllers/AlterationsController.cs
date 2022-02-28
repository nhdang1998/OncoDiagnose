using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.Utility;
using OncoDiagnose.Web.ViewModels;

namespace OncoDiagnose.Web.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Database_Manager + "," + SD.Role_User_Laboratory + "," + SD.Role_User_Doctor)]
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