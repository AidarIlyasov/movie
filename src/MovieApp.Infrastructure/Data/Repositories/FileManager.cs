using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MovieApp.Core.Interfaces;
using System.IO;
using System;
using System.Security.Cryptography;
using MovieApp.Core.Helpers;

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

        public async Task<int> SaveImage(IFormFile image, string folderName, int imageName)
        {
            try
            {
                var savePath = Path.Combine(_imagePath, "images", folderName);
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }

                var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
                var fileName = $"{imageName}{mime}";
                using (var fileStream = new FileStream(Path.Combine(savePath, fileName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                return imageName;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
