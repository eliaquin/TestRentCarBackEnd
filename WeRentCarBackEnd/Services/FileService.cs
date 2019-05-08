using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace WeRentCarBackEnd.Services
{
    public interface IFileService
    {
        Task<bool> SaveFile(IFormFile file, string fileName);
    }
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> SaveFile(IFormFile file, string fileName)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);
            try
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                    return true;
                }
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
