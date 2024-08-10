namespace Ducks.Classes;

class Duck : Bird, IComparable<Duck>
{
  public int Size { get; set; }
  public Enums.KindOfDuck Kind { get; set; }
  public override string ToString()
  {
    return $"A {Size} inch {Kind}";
  }
  public int CompareTo(Duck? duckToCompare)
  {
    if (duckToCompare == null) return 1;
    if (Size > duckToCompare.Size) return 1;
    if (Size < duckToCompare.Size) return -1;
    return 0;
  }
}
