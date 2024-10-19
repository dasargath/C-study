namespace LinqPractice;

public class Program
{
    public static void Main(string[] args)
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        var top30Percent = numbers.Top(30);
        Console.WriteLine("30% чисел по убыванию: " + string.Join(", ", top30Percent));

        var car = new List<Cars>
        {
            new Cars{Logo = "Acura", Id = 1},
            new Cars{Logo = "Ford", Id = 2},
            new Cars{Logo = "Renault", Id = 3},
            new Cars{Logo = "HongQi", Id = 4}
        };

        var top40PercentId = car.Top(40, c => c.Id);
        var top40PercentName = car.Top(40, c => c.Logo);
        Console.WriteLine("40% машин по убыванию по Id: " 
                          + string.Join(", ", top40PercentId.Select(c => c.Id)));
        Console.WriteLine("40% машин по убыванию по марке: " 
                          + string.Join(", ", top40PercentName.Select(c => c.Logo)));
    }

    private class Cars
    {
        public int Id { get; set; }
        public string? Logo { get; set; }
    }
}