using System.Collections.Concurrent;

namespace ObservablePattern;

public class LibrarianCommands
{
    private ConcurrentDictionary<string, int> books = new ConcurrentDictionary<string, int>();
    public bool IsRunning { get; set; } = true;
    public int BookCount => books.Count;
    
    public void AddBook()
    {
        Console.WriteLine("Введите название книги:");
        string bookName = Console.ReadLine();

        if (!books.ContainsKey(bookName))
        {
            books.TryAdd(bookName, 0);
        }
        else
        {
            Console.WriteLine("Эта книга уже добавлена."); 
        }
    }

    public void ShowBooks()
    {
        foreach (var book in books)
        {
            Console.WriteLine($"{book.Key} - прочитано {book.Value}%."); 
        }
    }

    public void UpdateBookProgress()
    {
        while (IsRunning)
        {
            Thread.Sleep(1000);

            foreach (var book in books.Keys)
            {
                books.AddOrUpdate(book, 0, (key, oldValue) => oldValue < 100?oldValue+1 : 100);
                if (books[book] >= 100)
                {
                    books.TryRemove(book, out _);
                }
            }
        }
    }
}