namespace Clown;

class FunnyFunny(string funnyThingIHave) : IClown
{
    private readonly string funnyThingIHave = funnyThingIHave;
    public string FunnyThingIHave => funnyThingIHave;

    public void Honk() => Console.WriteLine($"Hi kids! I have a {FunnyThingIHave}!");
}

class ScaryScary(string funnyThingIHave, int scaryThingCount) :
  FunnyFunny(funnyThingIHave), IScaryClown
{
    private readonly int scaryThingCount = scaryThingCount;
    public string ScaryThingIHave => $"{scaryThingCount} spiders";
    public void ScareLittleChildren()
    {
        Console.WriteLine($"Boo! Gotcha! Look at my {ScaryThingIHave}!");
    }
}

class TallGuy : IClown
{
    public string? Name { get; set; }
    public int Height { get; set; }
    public string FunnyThingIHave => "big red shoes";
    public void Honk() => Console.WriteLine("Honk honk!");
    public override string ToString() => $"TallGuy {Name} {Height} height";
}
