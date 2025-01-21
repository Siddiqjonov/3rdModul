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

        [HttpPost("createFolder")]
        public void CreateFolder(string directoryPath)
        {
            _storageService.CreateDirectory(directoryPath);
        }

        [HttpPost("uploadFile")]
        public void UploadFile(string? filePath, IFormFile file)
        {
            filePath = filePath ?? string.Empty;
            filePath = Path.Combine(filePath, file.FileName);
            using (var stream = file.OpenReadStream())
            {
                _storageService.UploadFile(filePath, stream);
            }
        }

        [HttpPost("uploadFiles")]
        public void UploadFiles(string? filePath, List<IFormFile> files)
        {
            filePath = filePath ?? string.Empty;
            var mainPath = filePath;
            foreach (var file in files)
            {
                filePath = Path.Combine(mainPath, file.FileName);
                using (var stream = file.OpenReadStream())
                {
                    _storageService.UploadFile(filePath, stream);
                }
            }
        }

        [HttpGet("getAll")]
        public List<string> GetAllFilesAndDirectories(string? directoryPath)
        {
            directoryPath ??= string.Empty;
            return _storageService.GetAllFilesAndDirectories(directoryPath);
        }
        [HttpGet("downloadFile")]
        public FileStreamResult DownloadFile(string filePath)
        {
            var stream = _storageService.DownloadFile(filePath);
            var fileName = Path.GetFileName(filePath);

            var result = new FileStreamResult(stream, "application/octet-stream")
            {
                FileDownloadName = filePath
            };
            return result;
        }

        [HttpGet("downloadFolderAsZip")]
        public FileStreamResult DownloadFolderAsZip(string directoryPath)
        {
            var foldersStream = _storageService.DownloadDirectoryAsZip(directoryPath);
            var foldersResult = new FileStreamResult(foldersStream, "application/octet-stream")
            {
                FileDownloadName = directoryPath + ".zip"
            };
            return foldersResult;
        }
        [HttpDelete("deleteFile")]
        public void DeleteFile(string filePath)
        {
            _storageService.DeleteFile(filePath);
        }
        [HttpDelete("deleteFolder")]
        public void DeleteFolder(string directoryPath)
        {
            _storageService.DeleteDirectory(directoryPath);
        }
    }
}
