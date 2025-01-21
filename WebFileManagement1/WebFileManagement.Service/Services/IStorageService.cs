using System.Globalization;

namespace WebFileManagement.Service.Services;

public interface IStorageService
{
    void UploadFile(string filePath, Stream stream);
    void CreateDirectory(string directoryPath);
    List<string> GetAllFilesAndDirectories(string directoryPath);
    Stream DownloadFile(string filePath);
    Stream DownloadDirectoryAsZip(string directoryPath);
    void DeleteFile(string filePath);
    void DeleteDirectory(string directoryPath);
}