using Animals.Models;

namespace Animals.Classes;

class Wolf : Canine, IPackHunter
{
    public Wolf(int age) : base(age, "Wolf") { }
    public Wolf(int age, bool belongsToPack) : base(age, "Wolf")
    {
        BelongsToPack = belongsToPack;
    }
    public override void MakeNoise()
    {
        Console.WriteLine(BelongsToPack ? "I'm in a pack" : "Aroo!");
    }
    public void HuntInPack()
    {
        Console.WriteLine(BelongsToPack ? "I'm going hunting with my pack!" : "I'm not in a pack");
    }
}
