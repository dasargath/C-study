namespace Collections;

public static class Program
{
    static void Main(string[] args)
    {
        OtusDictionary dict = new OtusDictionary();
        
        dict.Add(1, "один");
        dict.Add(5, "пять");
        
        Console.WriteLine(dict.Get(1));
        Console.WriteLine(dict.Get(5));
        Console.WriteLine(dict.Get(2));
        
        dict[5] = "шесть";
        Console.WriteLine(dict[5]);

        for (int i = 0; i < 40; i++)
        {
            dict.Add(i, $"Значение{i}");
        }
        Console.WriteLine(dict.Get(35));
    }
}