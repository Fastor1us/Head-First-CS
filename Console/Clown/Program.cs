namespace Clown;

class Program
{
    static void Main(string[] args)
    {
        IClown.CarCapacity = 18;
        Console.WriteLine(IClown.ClownCarDescription());
        IClown fingersTheClown = new ScaryScary("big red nose", 14);
        fingersTheClown.Honk();
        if (fingersTheClown is IScaryClown iScaryClownReference)
        {
            iScaryClownReference.ScareAdults();
        }
        TallGuy tallGuy = new() { Height = 76, Name = "Jimmy" };
        Console.WriteLine(tallGuy);
    }
}
