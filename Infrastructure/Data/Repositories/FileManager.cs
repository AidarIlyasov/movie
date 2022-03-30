using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MovieApp.Application.Interfaces;
using System.IO;
using System;

namespace MovieApp.Infrastructure.Data.Repositories
{
    public class FileManager : IFileManager
    {
        private string _imagePath;

        public FileManager(IConfiguration configuration)
        {
            _imagePath = configuration["Path:Movie"];
        }

        public FileStream ImageStream(string image)
        {
            var path = Path.Combine(_imagePath, "images", image);

            var file = File.Exists(path) 
                ? path 
                : Path.Combine(_imagePath, "images", "default.jpg");

            return new FileStream(file, FileMode.Open, FileAccess.Read);
        }

        public async Task<string> SaveImage(IFormFile image, string imagePath = "")
        {
            try
            {
                var savePath = Path.Combine(_imagePath, "images", imagePath);
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }

                var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
                var fileName = $"img_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mime}";

                using (var fileStream = new FileStream(Path.Combine(savePath, fileName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                return fileName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error";
            }
        }
    }
}
