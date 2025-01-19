using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFileManagement.Service.Services;

namespace WebFileManagement.Server.Controllers
{
    [Route("api/storage")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }
        // we use post to create thing
        [HttpPost("uploadFile")]
        public void UploadFile(IFormFile file, string filePath)
        {
            var directoryPath = Path.Combine(filePath, file.FileName);
            using (var stream = file.OpenReadStream())
            {
                _storageService.UploadFile(directoryPath, stream);
            }
        }
        [HttpPost("createFolder")]
        public void CreateFolder(string directoryPath)
        {
            _storageService.CreateDirectory(directoryPath);
        }
        [HttpGet("getAll")]
        public List<string> GetAll(string? directoryPath)
        {
            directoryPath = directoryPath ?? string.Empty;
            var allInfo = _storageService.GetAllFilesAndDirectories(directoryPath);
            return allInfo;
        }
    }
}
