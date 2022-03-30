using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Interfaces;

namespace MovieApp.backend.Controllers
{
    public class HomeController: Controller
    {
        IFileManager _fileManager;
        public HomeController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        [HttpGet("dashboard/[controller]")]
        public ActionResult Index()
        {
            return Content("Hello world from dashboard!");
        }


        [HttpGet("dashboard/pages")]
        public IActionResult Pages()
        {
            return Ok("Hello world from dashboard Api");
        }

        //todo remove this
        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }
    }
}