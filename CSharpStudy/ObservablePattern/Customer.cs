using System.Collections.Specialized;

namespace ObservablePattern;

public class Customer
{
    public void OnItemChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            foreach (Item newItem in e.NewItems)
            {
                Console.WriteLine($"Добавил книгу: {newItem.Name}");
            }
        }

        if (e.Action == NotifyCollectionChangedAction.Remove)
        {
            foreach (Item oldItem in e.OldItems)
            {
                Console.WriteLine($"Удалил книгу: {oldItem.Name}");
            }
        }
    }
}