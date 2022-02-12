using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OncoDiagnose.Web.Business;

namespace OncoDiagnose.Web.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class DrugsController : Controller
    {
        private readonly DrugBusiness _drugBusiness;

        public DrugsController(DrugBusiness drugBusiness)
        {
            _drugBusiness = drugBusiness;
        }

        // GET: Doctor/Mutations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mutation = await _drugBusiness.GetById(id);

            if (mutation == null)
            {
                return NotFound();
            }

            return View(mutation);
        }
    }
}