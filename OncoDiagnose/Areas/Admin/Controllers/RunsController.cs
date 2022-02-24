using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.ViewModels;

namespace OncoDiagnose.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RunsController : Controller
    {
        private readonly RunBusiness _runBusiness;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RunsController(RunBusiness runBusiness, IWebHostEnvironment webHostEnvironment)
        {
            _runBusiness = runBusiness;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allObj = await _runBusiness.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var objFromDb = await _runBusiness.GetById(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            ClearImageInFolder(objFromDb);

            await _runBusiness.Delete(objFromDb);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var runViewModel = new RunViewModel();
            if (id == null) return View(runViewModel);
            runViewModel = await _runBusiness.GetById(id.GetValueOrDefault());
            if (runViewModel == null) return NotFound();
            return View(runViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(RunViewModel runViewModel)
        {
            switch (ModelState.IsValid)
            {
                case true:
                    {
                        await UpdateImages(runViewModel);

                        if (runViewModel.Id == 0)
                        {
                            await _runBusiness.Add(runViewModel);
                        }
                        else
                        {
                            await _runBusiness.Update(runViewModel);
                        }
                        return RedirectToAction("Index");
                    }
                default:
                    return View(runViewModel);
            }
        }

        private async Task UpdateImages(RunViewModel runViewModel)
        {
            var runFromDb = await _runBusiness.GetById(runViewModel.Id);
            var webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            string tmpISPLoadingPic = null;
            string tmpQualityPic = null;
            string tmpLengthPic = null;

            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    switch (file.Name)
                    {
                        case "ISPLoadingPic":
                            {
                                var fileName = Guid.NewGuid().ToString();
                                var uploads = Path.Combine(webRootPath, @"photo\ISPLoadingPic");
                                var extension = Path.GetExtension(file.FileName);

                                runViewModel.ISPLoadingPic = @"\photo\ISPLoadingPic\" + fileName + extension;
                                tmpISPLoadingPic = runViewModel.ISPLoadingPic;

                                if (runViewModel.ISPLoadingPic != null)
                                {
                                    //This is an edit and we need to remove old image
                                    if (runFromDb.ISPLoadingPic != null)
                                    {
                                        var imagePath = Path.Combine(webRootPath, runFromDb.ISPLoadingPic.TrimStart('\\'));
                                        DeleteImage(imagePath);
                                    }
                                }

                                await AddImage(uploads, fileName, extension, file);
                                break;
                            }
                        case "QualityPic":
                            {
                                var fileName = Guid.NewGuid().ToString();
                                var uploads = Path.Combine(webRootPath, @"photo\QualityPic");
                                var extension = Path.GetExtension(file.FileName);

                                runViewModel.QualityPic = @"\photo\QualityPic\" + fileName + extension;
                                tmpQualityPic = runViewModel.QualityPic;

                                if (runViewModel.QualityPic != null)
                                {
                                    //This is an edit and we need to remove old image
                                    if (runFromDb.QualityPic != null)
                                    {
                                        var imagePath = Path.Combine(webRootPath, runFromDb.QualityPic.TrimStart('\\'));
                                        DeleteImage(imagePath);
                                    }
                                }

                                await AddImage(uploads, fileName, extension, file);
                                break;
                            }
                        case "LengthPic":
                            {
                                var fileName = Guid.NewGuid().ToString();
                                var uploads = Path.Combine(webRootPath, @"photo\LengthPic");
                                var extension = Path.GetExtension(file.FileName);

                                runViewModel.LengthPic = @"\photo\LengthPic\" + fileName + extension;
                                tmpLengthPic = runViewModel.LengthPic;

                                if (runViewModel.LengthPic != null)
                                {
                                    //This is an edit and we need to remove old image
                                    if (runFromDb.LengthPic != null)
                                    {
                                        var imagePath = Path.Combine(webRootPath, runFromDb.LengthPic.TrimStart('\\'));
                                        DeleteImage(imagePath);
                                    }
                                }

                                await AddImage(uploads, fileName, extension, file);
                                break;
                            }
                        default:
                            continue;
                    }
                }

                VerifyImageChanges(runViewModel, runFromDb, tmpISPLoadingPic, tmpQualityPic, tmpLengthPic);
            }
            else
            {
                //Update when they don't change the image
                KeepOldImages(runViewModel, runFromDb);
            }
        }

        private void ClearImageInFolder(RunViewModel objFromDb)
        {
            var webRootPath = _webHostEnvironment.WebRootPath;

            var picPath = Path.Combine(webRootPath, objFromDb.ISPLoadingPic.TrimStart('\\'));
            DeleteImage(picPath);

            picPath = Path.Combine(webRootPath, objFromDb.QualityPic.TrimStart('\\'));
            DeleteImage(picPath);

            picPath = Path.Combine(webRootPath, objFromDb.LengthPic.TrimStart('\\'));
            DeleteImage(picPath);
        }

        private static void DeleteImage(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

        private static void KeepOldImages(RunViewModel runViewModel, RunViewModel runFromDb)
        {
            if (runViewModel.Id == 0) return;
            runViewModel.ISPLoadingPic = runFromDb.ISPLoadingPic;
            runViewModel.QualityPic = runFromDb.QualityPic;
            runViewModel.LengthPic = runFromDb.LengthPic;
        }

        private static void VerifyImageChanges(RunViewModel runViewModel, RunViewModel runFromDb, string pathISPLoadingPic,
            string pathQualityPic, string pathLengthPic)
        {
            //Make sure the update don't effect to other images
            if (pathISPLoadingPic == null)
            {
                runViewModel.ISPLoadingPic = runFromDb.ISPLoadingPic;
            }

            if (pathQualityPic == null)
            {
                runViewModel.QualityPic = runFromDb.QualityPic;
            }

            if (pathLengthPic == null)
            {
                runViewModel.LengthPic = runFromDb.LengthPic;
            }
        }

        private static async Task AddImage(string uploads, string fileName, string? extension, IFormFile file)
        {
            await using var fileStreams =
                         new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create);
            await file.CopyToAsync(fileStreams);
        }
    }
}