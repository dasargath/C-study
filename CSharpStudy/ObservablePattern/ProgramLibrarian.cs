using System.Collections.Concurrent;


namespace ObservablePattern;

public class ProgramLibrarian
{

    public static void Main(string[] args)
    {
        var librarian = new LibrarianCommands();
        var bgThread = new Thread(librarian.UpdateBookProgress);
        
        bgThread.Start();

        while (librarian.IsRunning)
        {
            Console.WriteLine("1 - добавить книгу; 2 - вывести список непрочитанного; 3 - выйти");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    librarian.AddBook();
                    break;
                case "2":
                    if (librarian.BookCount > 0)
                    {
                        librarian.ShowBooks();
                    }
                    else
                    {
                        Console.WriteLine("Список пуст. Добавьте книгу или нажмите выход.");
                    }
                    break;
                case "3":
                    librarian.IsRunning = false;
                    break;
                default:
                    Console.WriteLine("Неправильная команда");
                    break;
            }
        }
        bgThread.Join();
    }
}