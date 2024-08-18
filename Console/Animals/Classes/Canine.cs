namespace Animals.Classes;

abstract class Canine(int age, string name) : Animal(name)
{
    public override int Age => age;
    public bool BelongsToPack { get; protected set; } = false;
}
