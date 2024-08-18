namespace ASafeSafe;

internal class Program
{
    static void Main(string[] args)
    {
        SafeOwner owner = new();
        Safe safe = new();
        JewelThief jewelThief = new();
        jewelThief.OpenSafe(safe, owner);
        Console.ReadKey(true);
    }
}
