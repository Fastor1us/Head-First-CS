namespace HiLo;

internal static class HiLoGame
{
    public const int MAXIMUM = 10;
    private static readonly Random random = new();
    private static int currentNumber = random.Next(1, MAXIMUM + 1);

    public static int Pot { get; private set; } = 10;

    public static void Guess(bool higher)
    {
        int nextNumber = random.Next(1, MAXIMUM + 1);

        bool isGuessedRight =
            (higher && nextNumber >= currentNumber) || !higher && nextNumber <= currentNumber;
        Pot += isGuessedRight ? 1 : -1;
        Console.WriteLine(isGuessedRight ? "You guessed right!" : "Bad luck, you guessed wrong");

        currentNumber = nextNumber;
        Console.WriteLine($"The current number is {currentNumber}");
    }

    public static void Hint()
    {
        int half = MAXIMUM / 2;
        string relativePosition = currentNumber >= half ? "least" : "most";
        Console.WriteLine($"Hint: the number is at {relativePosition} {half}");
        Pot--;
    }
}
