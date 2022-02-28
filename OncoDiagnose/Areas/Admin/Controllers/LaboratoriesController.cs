using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess;
using OncoDiagnose.Models.AuthenticateAndAuthorize;
using OncoDiagnose.Web.Business.Security;
using OncoDiagnose.Web.Utility;
using OncoDiagnose.Web.ViewModels.Security;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Database_Manager)]
    public class LaboratoriesController : Controller
    {
        private readonly LaboratoryBusiness _laboratoryBusiness;

        public LaboratoriesController(LaboratoryBusiness laboratoryBusiness)
        {
            _laboratoryBusiness = laboratoryBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _laboratoryBusiness.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _laboratoryBusiness.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            await _laboratoryBusiness.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var laboratoryViewModel = new LaboratoryViewModel();

            if (id == null) return View(laboratoryViewModel);
            laboratoryViewModel = await _laboratoryBusiness.GetById(id.GetValueOrDefault());
            if (laboratoryViewModel == null) return NotFound();
            return View(laboratoryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(LaboratoryViewModel laboratoryViewModel)
        {
            switch (ModelState.IsValid)
            {
                case true:
                    {
                        if (laboratoryViewModel.Id == 0)
                        {
                            await _laboratoryBusiness.Add(laboratoryViewModel);
                        }
                        else
                        {
                            await _laboratoryBusiness.Update(laboratoryViewModel);
                        }
                        return RedirectToAction("Index");
                    }
                default:
                    return View(laboratoryViewModel);
            }
        }
    }
}