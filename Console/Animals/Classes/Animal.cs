namespace Animals.Classes;

abstract class Animal(string name)
{
    public string Name => name;
    public abstract int Age { get; }
    public abstract void MakeNoise();
    public virtual void Sleep()
    {
        Console.WriteLine("The animal is sleeping");
    }
}
