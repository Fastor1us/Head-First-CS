namespace EggsSpawner;

internal class Pigeon : Bird
{
    public override Egg[] LayEggs(int numberOfEggs)
    {
        Egg[] eggs = new Egg[numberOfEggs];
        for (int i = 0; i < eggs.Length; i++)
        {
            if (Randomizer.Next(4) == 0)
                eggs[i] = new BrokenEgg();
            else
                eggs[i] = new Egg(Randomizer.NextDouble() * 2 + 1, "white");
        }
        return eggs;
    }
}
