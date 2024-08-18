namespace EggsSpawner;

internal class Ostrich : Bird
{
    public override Egg[] LayEggs(int numberOfEggs)
    {
        Egg[] eggs = new Egg[numberOfEggs];
        for (int i = 0; i < eggs.Length; i++)
            eggs[i] = new Egg(Randomizer.NextDouble() + 12, "speckled");
        return eggs;
    }
}
