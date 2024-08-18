using Animals.Classes;
using Animals.Models;

namespace Animals;

internal class Program()
{
    static void Main(string[] args)
    {
        Animal[] animals = [
            new Hippo(10),
            new Wolf(15),
            new Wolf(5, true)
        ];
        foreach (Animal animal in animals)
        {
            animal.MakeNoise();
            if (animal is ISwimmer swimmer)
                swimmer.Swim();
            if (animal is IPackHunter packHunter)
                packHunter.HuntInPack();
        }
    }
}
