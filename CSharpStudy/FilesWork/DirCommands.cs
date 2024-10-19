using System.Text;

namespace FilesWork;

public class DirCommands
{
    public static void CreateDirIfNotExists(string baseRootDir)
    {
        DirectoryInfo dir = new DirectoryInfo(baseRootDir);
        if (!dir.Exists)
        {
            dir.Create();
        }
        else
        {
            Console.WriteLine($"Директория {baseRootDir} уже существует. Файлы будут сохранены в ней.\n");
        }
    }

         
    public static async Task CreateWriteFileAsync(string baseRootDir)
    {
        for (int i = 0; i < 10; i++)
        {
            string filePath = Path.Combine(baseRootDir, $"File{i}.txt");

            try
            {
                if (File.Exists(filePath))
                {
                    throw new IOException($"Файл \"{Path.GetFileName(filePath)}\" уже существует.\n");
                }
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    string content = $"Имя файла: File{i}\nДата: {DateTime.Now}";
                    await sw.WriteLineAsync(content);
                }
            }

            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"У вас нет прав на перезапись: {i}. Ошибка: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка записи файла: {i}. Ошибка: {ex.Message}");
            }
        }
    }

    
    public static void ReadDisplayFiles(string baseRootDir)
    {
        DirectoryInfo dir = new DirectoryInfo(baseRootDir);
        FileInfo[] files = dir.GetFiles("*.txt");
        try
        {
            foreach (var file in files)
            {
                using (FileStream fs = file.OpenRead())
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    string content = sr.ReadToEnd();
                    Console.WriteLine($"Файл: {file.Name}");
                    Console.WriteLine(content);
                }
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Такого файла не существует. Ошибка: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка считывания файла. Ошибка: {ex.Message}");
        }
    }
}
