using System.Collections.Immutable;

namespace ObservablePattern;

public class ProgramJacksHouse
{
    static void Main(string[] args)
    {
        var poemParts = new Func<ImmutableList<string>, ImmutableList<string>>[]
        {
            poem => new Part1().AddPart(poem),
            poem => new Part2().AddPart(poem),
            poem => new Part3().AddPart(poem),
            poem => new Part4().AddPart(poem),
            poem => new Part5().AddPart(poem),
            poem => new Part6().AddPart(poem),
            poem => new Part7().AddPart(poem),
            poem => new Part8().AddPart(poem),
            poem => new Part9().AddPart(poem),
        };
        
        ImmutableList<string> poem = ImmutableList<string>.Empty;

        foreach (var poemPart in poemParts)
        {
            poem = poemPart(poem);
            Console.WriteLine(poem[^1]);
        }
    }
}