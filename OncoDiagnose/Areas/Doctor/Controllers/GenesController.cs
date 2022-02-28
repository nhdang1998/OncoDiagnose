using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.Utility;

namespace OncoDiagnose.Web.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Database_Manager + "," + SD.Role_User_Laboratory + "," + SD.Role_User_Doctor)]
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