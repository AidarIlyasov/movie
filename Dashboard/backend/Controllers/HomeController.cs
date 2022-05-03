using System.IO;
using Fall.Core.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Interfaces;

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
        [AllowAnonymous]
        [HttpGet("/Image/{image}")]
        [HttpGet("/Image/{folder:int}/{image}")]
        public IActionResult Image(int folder = 0, string image = "")
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);
            if (folder != 0) image = string.Concat(folder, "/", image);
            
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }
    }
}