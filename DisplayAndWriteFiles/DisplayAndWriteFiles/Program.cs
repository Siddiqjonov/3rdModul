namespace DisplayAndWriteFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"C:\Users\ACer\Downloads\Telegram Desktop\Files";
            var files = Directory.GetFiles(directoryPath);

            foreach (var file in files)
            {
                if (file.Contains("result")) continue;
                new Thread(() => DisplayAndWriteFiles(file)).Start();
            }
        }

        public static Object _lock = new Object();

        public static void DisplayAndWriteFiles(string path)
        {
            var savePath = @"C:\Users\ACer\Downloads\Telegram Desktop\Files\result.txt";
            lock (_lock)
            {
                var count = File.ReadAllText(path).Count(ch => char.IsDigit(ch));
                var line = $"File: {path.Substring(path.LastIndexOf("\\") + 1)}, Digits: {count}, Thread ID: {Thread.CurrentThread.ManagedThreadId}";
                Console.WriteLine(line);
                using StreamWriter stream = new StreamWriter(savePath, true);
                stream.WriteLine(line);
            }
        }
    }
}
