using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFileManagement.SorageBroker.Services;

public class DropBoxStorageBrokerService : IStorageBrokerService
{
    public void CreateDirectory(string directoryPath)
    {
        throw new NotImplementedException();
    }

    public void DeleteDirectory(string directoryPath)
    {
        throw new NotImplementedException();
    }

    public void DeleteFile(string filePath)
    {
        throw new NotImplementedException();
    }

    public Stream DownloadDirectoryAsZip(string directoryPath)
    {
        throw new NotImplementedException();
    }

    public Stream DownloadFile(string filePath)
    {
        throw new NotImplementedException();
    }

    public List<string> GetAllFilesAndDirectories(string directoryPath)
    {
        throw new NotImplementedException();
    }

    public void UploadFile(string filePath, Stream stream)
    {
        throw new NotImplementedException();
    }
}
