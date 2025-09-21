
namespace Final_Task.SaveLoadData
{
    internal class FileSystemSaveLoadService : ISaveLoadService<string>
    {
        private string _dirPath;
        public FileSystemSaveLoadService(string path)
        {
            _dirPath = path;
            if (!Directory.Exists(_dirPath))
            {
                Directory.CreateDirectory(_dirPath);
            }
        }

        public string LoadData(string filename)
        {
            string fullPath = Path.Combine(_dirPath, $"{filename}.txt");
            try
            {
                if (File.Exists(fullPath))
                {
                    Console.WriteLine($"Profile from {fullPath} is loaded.");
                    return File.ReadAllText(fullPath);
                }
                else
                {
                    Console.WriteLine($"File {fullPath} does not exist");
                    return "-1";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error trying to load the file:\n{ex.Message}");
                return "-1";
            }
        }

        public void SaveData(string data, string filename)
        {
            try
            {
                string fullPath = Path.Combine(_dirPath, $"{filename}.txt");
                File.WriteAllText(fullPath, data);
                Console.WriteLine($"Profile saved to {fullPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
