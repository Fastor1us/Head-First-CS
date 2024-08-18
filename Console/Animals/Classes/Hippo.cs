using Animals.Models;

namespace Animals.Classes;

class Hippo(int age) : Animal("Hippo"), ISwimmer
{
    public override int Age => age;
    public override void MakeNoise()
    {
        Console.WriteLine("*yawn*");
    }
    public void Swim()
    {
        Console.WriteLine("Hippo is swimming...");
    }
}
