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
            Console.WriteLine($"Directory {baseRootDir} already exists. Files will be saved there.\n");
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
                    throw new IOException($"File \"{Path.GetFileName(filePath)}\" already exists.\n");
                }
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    string content = $"File name: File{i}\nDate: {DateTime.Now}";
                    await sw.WriteLineAsync(content);
                }
            }

            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"You have no rights to save in file: {i}. Error: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File save error: {i}. Error: {ex.Message}");
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
                    Console.WriteLine($"File: {file.Name}");
                    Console.WriteLine(content);
                }
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"There is no file specified. Error: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File read error. Error: {ex.Message}");
        }
    }
}
