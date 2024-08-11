namespace Ducks;

class Bird
{
  public string? Name { get; set; }
  public override string ToString()
  {
    return $"A bird named {Name}";
  }
  public virtual void Fly(string destination)
  {
    Console.WriteLine($"{this} is flying to {destination}");
  }
  public static void FlyAway(List<Bird> flock, string destination)
  {
    foreach (Bird bird in flock)
    {
      bird.Fly(destination);
    }
  }
}
