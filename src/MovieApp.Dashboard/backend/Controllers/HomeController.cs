using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Interfaces;

namespace MovieApp.backend.Controllers
{
    [ApiController]
    [Route("/dashboard/[controller]/")]
    public class HomeController: ControllerBase
    {
        IFileManager _fileManager;
        public HomeController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("name")]
        public IActionResult GetLogin()
        {
            return Ok($"Your login: {User.Identity?.Name}");
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