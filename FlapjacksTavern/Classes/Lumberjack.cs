namespace FlapjacksTavern.Classes;

internal class Lumberjack(string name)
{
  public string Name { get; set; } = name;
  private readonly Stack<Enums.Flapjack> flapjackStack = new();
  public void TakeFlapjack(Enums.Flapjack flapjack)
  {
    flapjackStack.Push(flapjack);
  }
  public void EatFlapjacks()
  {
    if (flapjackStack.Count > 0)
    {
      Console.WriteLine($"{Name} is eating flapjacks:");
      while (flapjackStack.Count > 0)
      {
        string flapjack = flapjackStack.Pop().ToString().ToLower();
        Console.WriteLine($"- {Name} ate a {flapjack} flapjack");
      }
    }
    else
    {
      Console.WriteLine($"{Name} has nothing to eat");
    }
  }
}
