using System.Collections.Immutable;

namespace ObservablePattern;


public class PartBase
{
    protected ImmutableList<string> Poem { get; set; } = ImmutableList<string>.Empty;

    public virtual ImmutableList<string> AddPart(ImmutableList<string> originalPoem)
    {
        return originalPoem;
    }
}
public class Part1 : PartBase
{
    public override ImmutableList<string> AddPart (ImmutableList<string> previousPart)
    {
        Poem = previousPart.Add("Вот дом,\nКоторый построил Джек.\n");
        return Poem;
    }
}

public class Part2 : PartBase
{
    public override ImmutableList<string> AddPart (ImmutableList<string> previousPart)
    {
        Poem = previousPart.Add("А это пшеница,\nKоторая в темном чулане хранится\nВ доме, который построил Джек.\n");
        return Poem;
    }
}

public class Part3 : PartBase
{
    public override ImmutableList<string> AddPart (ImmutableList<string> previousPart)
    {
        Poem = previousPart.Add("А это веселая птица-синица,\nКоторая часто ворует пшеницу,\nКоторая в темном чулане " +
                                "хранится\nВ доме,\nКоторый построил Джек.\n");
        return Poem;
    }
}

public class Part4 : PartBase
{
    public override ImmutableList<string> AddPart (ImmutableList<string> previousPart)
    {
        Poem = previousPart.Add("Вот кот,\nКоторый пугает и ловит синицу,\nКоторая часто ворует пшеницу,\n" +
                                "Которая в темном чулане хранится\nВ доме,\nКоторый построил Джек.\n");
        return Poem;
    }
}

public class Part5 : PartBase
{
    public override ImmutableList<string> AddPart (ImmutableList<string> previousPart)
    {
        Poem = previousPart.Add("Вот пес без хвоста,\nКоторый за шиворот треплет кота,\nКоторый пугает и ловит синицу,\n" +
                                "Которая часто ворует пшеницу,\nКоторая в темном чулане хранится\nВ доме,\n" +
                                "Который построил Джек.\n");
        return Poem;
    }
}

public class Part6 : PartBase
{
    public override ImmutableList<string> AddPart (ImmutableList<string> previousPart)
    {
        Poem = previousPart.Add("А это корова безрогая,\nЛягнувшая старого пса без хвоста,\n" +
                                "Который за шиворот треплет кота,\nКоторый пугает и ловит синицу,\n" +
                                "Которая часто ворует пшеницу,\nКоторая в темном чулане хранится\n" +
                                "В доме,\nКоторый построил Джек.\n");
        return Poem;
    }
}

public class Part7 : PartBase
{
    public override ImmutableList<string> AddPart (ImmutableList<string> previousPart)
    {
        Poem = previousPart.Add("А это старушка, седая и строгая,\nКоторая доит корову безрогую,\nЛягнувшую старого " +
                                "пса без хвоста,\nКоторый за шиворот треплет кота,\nКоторый пугает и ловит синицу,\n" +
                                "Которая часто ворует пшеницу,\nКоторая в темном чулане хранится\nВ доме,\nКоторый " +
                                "построил Джек.\n");
        return Poem;
    }
}

public class Part8 : PartBase
{
    public override ImmutableList<string> AddPart (ImmutableList<string> previousPart)
    {
        Poem = previousPart.Add("А это ленивый и толстый пастух,\nКоторый бранится с коровницей строгою,\nКоторая доит " +
                                "корову безрогую,\nЛягнувшую старого пса без хвоста,\nКоторый за шиворот треплет кота,\n" +
                                "Который пугает и ловит синицу,\nКоторая часто ворует пшеницу,\nКоторая в темном чулане" +
                                " хранится\nВ доме,\nКоторый построил Джек.\n");
        return Poem;
    }
}

public class Part9 : PartBase
{
    public override ImmutableList<string> AddPart (ImmutableList<string> previousPart)
    {
        Poem = previousPart.Add("Вот два петуха,\nКоторые будят того пастуха,\nКоторый бранится с коровницей строгою,\n" +
                                "Которая доит корову безрогую,\nЛягнувшую старого пса без хвоста,\nКоторый за шиворот " +
                                "треплет кота,\nКоторый пугает и ловит синицу,\nКоторая часто ворует пшеницу,\nКоторая " +
                                "в темном чулане хранится\nВ доме,\nКоторый построил Джек.\n");
        return Poem;
    }
}
