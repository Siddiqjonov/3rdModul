using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFileManagement.SorageBroker.Services;

public class LocalStorageBrokerService : IStorageBrokerService
{
    private readonly string _dataPath;
    public LocalStorageBrokerService()
    {
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "data");
        if (!Directory.Exists(_dataPath))
            Directory.CreateDirectory(_dataPath);
    }

    public void CreateDirectory(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        CheckParentExists(directoryPath);
        if (Directory.Exists(directoryPath))
            throw new Exception("Folder already exists");
        Directory.CreateDirectory(directoryPath);
    }

    public void DeleteFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        CheckParentExists(filePath);
        if (!File.Exists(filePath))
            throw new Exception("File does not exist");
        File.Delete(filePath);
    }

    public void DeleteDirectory(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        CheckParentExists(directoryPath);
        if (!Directory.Exists(directoryPath))
            throw new Exception("Folder does not exists");
        Directory.Delete(directoryPath);
    }

    public Stream DownloadDirectoryAsZip(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        CheckParentExists(directoryPath);
        if (!Directory.Exists(directoryPath) || string.IsNullOrEmpty(directoryPath) || Path.GetExtension(directoryPath) != string.Empty)
            throw new Exception("Folder does not exists");
        var zipPath = directoryPath + ".zip";

        ZipFile.CreateFromDirectory(directoryPath, zipPath);
        var stream = new FileStream(zipPath, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public Stream DownloadFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);
        CheckParentExists(filePath);
        if (!File.Exists(filePath) || string.IsNullOrEmpty(filePath) || Path.GetExtension(filePath) == string.Empty)
            throw new Exception("Invalid file is entered");
        var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        return stream;
    }

    public List<string> GetAllFilesAndDirectories(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        CheckParentExists(directoryPath);
        if (!Directory.Exists(directoryPath))
            throw new Exception("Folder already exists");
        var allFilesAndDirectories = Directory.EnumerateFileSystemEntries(directoryPath).ToList();
        allFilesAndDirectories = allFilesAndDirectories.Select(name => name.Remove(0, directoryPath.Length + 1)).ToList();
        return allFilesAndDirectories;
    }

    public void UploadFile(string filePath, Stream stream)
    {
        filePath = Path.Combine(_dataPath, filePath);
        CheckParentExists(filePath);
        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            stream.CopyTo(fileStream);
        }
    }
    private void CheckParentExists(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);
        var parentPath = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parentPath.FullName))
            throw new Exception("Parent folder does not exist");
    }
}
