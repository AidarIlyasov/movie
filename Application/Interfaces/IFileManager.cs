using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace MovieApp.Application.Interfaces
{
    public interface IFileManager
    {
        FileStream ImageStream(string name);

        Task<string> SaveImage(IFormFile image, string imagePath = "");
    }
}
