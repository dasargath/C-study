using System.Collections.ObjectModel;

namespace ObservablePattern;


public class ProgramRegularCustomer
{
    public static void Main(string[] args)
    {
        Shop shop = new Shop();
        Customer customer = new Customer();

        shop.Items.CollectionChanged += customer.OnItemChanged;

        while (true)
        {
            Console.WriteLine("Введите A чтобы добавить книгу, D чтобы удалить книгу, X для выхода: ");
            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.A:
                    var newItem = new Item
                    {
                        Id = shop.Items.Count + 1,
                        Name = $"Дата добавления: {DateTime.Now}"
                    };
                    shop.Add(newItem);
                    break;
                
                case ConsoleKey.D:
                    Console.WriteLine("Введите ID что бы удалить книгу: ");

                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        Item itemToDelete = null;

                        foreach (var item in shop.Items)
                        {
                            if (item.Id == id)
                            {
                                itemToDelete = item;
                                break;
                            }
                        }

                        if (itemToDelete != null)
                        {
                            shop.Items.Remove(itemToDelete);
                        }
                        else
                        {
                            Console.WriteLine("Книга не найдена");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неправильный формат ID книги. Введите ID в правильном формате.");
                    }
                    break;
                
                case ConsoleKey.X:
                    Console.WriteLine("Выхожу из программы. До встречи!");
                    return;
                
                default:
                    Console.WriteLine("Неправильная команда. Попробуйте еще раз.");
                    break;
            }
        }
    }
}
