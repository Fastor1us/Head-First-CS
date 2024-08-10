namespace Ducks;

class Program
{
  static void Main(string[] args)
  {
    List<Classes.Duck> ducks = [
      new() { Kind = Enums.KindOfDuck.Mallard, Size = 17 },
      new() { Kind = Enums.KindOfDuck.Muscovy, Size = 18 },
      new() { Kind = Enums.KindOfDuck.Loon, Size = 14 },
      new() { Kind = Enums.KindOfDuck.Muscovy, Size = 11 },
      new() { Kind = Enums.KindOfDuck.Mallard, Size = 14 },
      new() { Kind = Enums.KindOfDuck.Loon, Size = 13 },
    ];

    IEnumerable<Classes.Bird> upcastDucks = ducks;
    Classes.Bird.FlyAway(upcastDucks.ToList(), "Minnesota");

    ducks.Sort();
    PrintDucks(ducks);

    ducks.Sort(new Classes.DuckComparerBySize());
    PrintDucks(ducks);
  }

  public static void PrintDucks(List<Classes.Duck> ducks)
  {
    foreach (Classes.Duck duck in ducks)
    {
      Console.WriteLine(duck);
    }
  }
}
