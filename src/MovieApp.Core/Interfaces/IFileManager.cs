using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using MovieApp.Core.Helpers;

namespace MovieApp.Core.Interfaces
{
    public interface IFileManager
    {
        FileStream ImageStream(string name);

        Task<int> SaveImage(IFormFile image, string folderName, int imageName);
    }
}
