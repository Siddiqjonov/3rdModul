using System.Net.WebSockets;

namespace GetAllFilesInFolders
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string folderPath = @"D:\Full-stack\BackEnd\PDP_Academy\PDP_Homework\3rdModul\BookCRUD\BookCRUD.Api";
            DisplayAllFiles(folderPath);
        }
        
        public static void DisplayAllFiles(string folderPath)
        {
            var files = new List<string>();
            FillWithFiles(folderPath, files);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
            
        }
        private static List<string> FillWithFiles(string folderPath, List<string> files)
        {
            string[] filesInPath = Directory.GetFiles(folderPath);
            var foldersInPath = Directory.GetDirectories(folderPath);
            files.AddRange(filesInPath);
            foreach (var folder in foldersInPath)
            {
                FillWithFiles(folder, files);
            }
            
            return files;
        }




        public static void UnsuccesedMethod()
        {
            string directoryPath = @"C:\Users\ACer\Downloads";
            var files = Directory.GetFiles(directoryPath);
            var folders = Directory.GetDirectories(directoryPath);

            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
            Console.WriteLine();

            foreach (var folder in folders)
            {
                var filesInFolder = Directory.GetFiles(folder);
                foreach (var file in filesInFolder)
                {
                    Console.WriteLine(file);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
