using System.Text;

namespace FilesWork;

public class Program
{
    static async Task Main(string[] args)
    {
        string baseRootDir1 = @"c:\Otus\TestDir1";
        string baseRootDir2 = @"c:\Otus\TestDir2";
        
        DirCommands.CreateDirIfNotExists(baseRootDir1);
        DirCommands.CreateDirIfNotExists(baseRootDir2);
        
        await DirCommands.CreateWriteFileAsync(baseRootDir1);
        await DirCommands.CreateWriteFileAsync(baseRootDir2);
        
        DirCommands.ReadDisplayFiles(baseRootDir1);
        DirCommands.ReadDisplayFiles(baseRootDir2);
    }
}
