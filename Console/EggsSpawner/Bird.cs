namespace EggsSpawner;

abstract class Bird
{
    public static Random Randomizer = new();
    public abstract Egg[] LayEggs(int numberOfEggs);
}
