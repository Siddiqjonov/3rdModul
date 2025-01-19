using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFileManagement.StorageBroker.Services;

public class LocalStorageBrokerService : IStorageBrokerService
{
    private string _dataPath;
    public LocalStorageBrokerService()
    {
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "data");
        if (!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
        }
    }

    public void CreateDirectory(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        DirectoryInfo? parentPath = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parentPath.FullName))
        {
            throw new Exception("Rarent folder does not exists");
        }

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }

    public List<string> GetAllFilesAndDirectories(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        var parentPath = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parentPath.FullName))
            throw new Exception("Rarent folder does not exists");

        var filesAndDirectories = Directory.GetFileSystemEntries(directoryPath).ToList();
        filesAndDirectories = filesAndDirectories.Select(name => name.Remove(0, directoryPath.Length + 1)).ToList();
        return filesAndDirectories;
    }

    public void UploadFile(string filePath, Stream stream)
    {
        filePath = Path.Combine(_dataPath, filePath);
        DirectoryInfo? parentPath = Directory.GetParent(filePath);
        if (!Directory.Exists(parentPath.FullName))
            throw new Exception("Parent folder does not exits");

        using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            stream.CopyTo(fileStream);
        }
    }
}
