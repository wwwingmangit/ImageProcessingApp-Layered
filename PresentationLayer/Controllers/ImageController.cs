using System.Threading.Tasks;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace PresentationLayer.Controllers
{
    public class ImageController : Controller
    {
        private readonly ImageService _imageService;

        public ImageController()
        {
            _imageService = new ImageService();
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    var imageData = ms.ToArray();
                    var imageModel = await _imageService.UploadImageAsync(imageData, file.FileName);
                    return RedirectToAction("Details", new { id = imageModel.Id });
                }
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var imageModel = await _imageService.ApplyFilterAsync(id, "grayscale");
            return View(imageModel);
        }
    }
}
