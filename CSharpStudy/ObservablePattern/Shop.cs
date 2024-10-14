using System.Collections.ObjectModel;

namespace ObservablePattern;

public class Shop
{
    public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
    public void Add(Item item)
    {
        Items.Add(item);
    }
    
    public void Remove(Item item)
    {
        Items.Remove(item);
    }
}
