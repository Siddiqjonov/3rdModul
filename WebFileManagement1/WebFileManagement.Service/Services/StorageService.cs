using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFileManagement.SorageBroker.Services;

namespace WebFileManagement.Service.Services;

public class StorageService : IStorageService
{
    private IStorageBrokerService _storageBrokerService;

    public StorageService(IStorageBrokerService storageBrokerService)
    {
        _storageBrokerService = storageBrokerService;
    }

    public void CreateDirectory(string directoryPath)
    {
        _storageBrokerService.CreateDirectory(directoryPath);
    }

    public void DeleteDirectory(string directoryPath)
    {
        _storageBrokerService.DeleteDirectory(directoryPath);
    }

    public void DeleteFile(string filePath)
    {
        if (Path.GetExtension(filePath) == string.Empty || filePath == null)
            throw new Exception("Please enter file only!");
        _storageBrokerService.DeleteFile(filePath);
    }

    public Stream DownloadDirectoryAsZip(string directoryPath)
    {
        var stream = _storageBrokerService.DownloadDirectoryAsZip(directoryPath);
        return stream;
    }

    public Stream DownloadFile(string filePath)
    {
        var stream = _storageBrokerService.DownloadFile(filePath);
        return stream;
    }

    public List<string> GetAllFilesAndDirectories(string directoryPath)
    {
        var all = _storageBrokerService.GetAllFilesAndDirectories(directoryPath);
        return all;
    }

    public void UploadFile(string filePath, Stream stream)
    {
        _storageBrokerService.UploadFile(filePath, stream);
    }
}
