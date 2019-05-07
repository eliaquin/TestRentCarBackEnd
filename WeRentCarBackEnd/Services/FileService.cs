using Microsoft.AspNetCore.Http;

namespace WeRentCarBackEnd.Services
{
    public interface IFileService
    {
        bool SaveFile(IFormFile file, string fileName);
    }
    public class FileService : IFileService
    {

        public bool SaveFile(IFormFile file, string fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}
