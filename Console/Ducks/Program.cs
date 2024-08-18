namespace Ducks;

class Program
{
    static void Main(string[] args)
    {
        List<Duck> ducks =
        [
            new() { Kind = KindOfDuck.Mallard, Size = 17 },
            new() { Kind = KindOfDuck.Muscovy, Size = 18 },
            new() { Kind = KindOfDuck.Loon, Size = 14 },
            new() { Kind = KindOfDuck.Muscovy, Size = 11 },
            new() { Kind = KindOfDuck.Mallard, Size = 14 },
            new() { Kind = KindOfDuck.Loon, Size = 13 },
        ];

        IEnumerable<Bird> upcastDucks = ducks;
        Bird.FlyAway(upcastDucks.ToList(), "Minnesota");

        ducks.Sort();
        PrintDucks(ducks);

        // ducks.Sort(new DuckComparerBySize());
        // PrintDucks(ducks);
    }

    public static void PrintDucks(List<Duck> ducks)
    {
        foreach (Duck duck in ducks) Console.WriteLine(duck);
    }
}
