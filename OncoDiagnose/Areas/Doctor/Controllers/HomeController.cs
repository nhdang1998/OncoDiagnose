using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OncoDiagnose.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using OncoDiagnose.Web.Utility;

namespace OncoDiagnose.Web.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Database_Manager + "," + SD.Role_User_Laboratory + "," + SD.Role_User_Doctor + "," + SD.Role_User)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Intro()
        {
            return View();
        }

        public IActionResult IntroLungCancer()
        {
            return View();
        }

        public IActionResult IntroBreastCancer()
        {
            return View();
        }

        public IActionResult IntroThyroidCancer()
        {
            return View();
        }

        public IActionResult IntroLiverCancer()
        {
            return View();
        }

        public IActionResult IntroColorectalCancer()
        {
            return View();
        }

        public IActionResult OperationProcess()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}