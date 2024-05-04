namespace HiLo
{
    internal static class HiLoGame
    {
        public const int MAXIMUM = 10;
        private static Random random = new Random();
        private static int currentNumber = random.Next(1, MAXIMUM + 1);

        public static int Pot { get; private set; } = 10;

        public static void Guess(bool higher)
        {
            int nextNumber = random.Next(1, MAXIMUM + 1);

            if ((higher && nextNumber >= currentNumber) || !higher && nextNumber <= currentNumber)
            {
                Console.WriteLine("You guessed right!");
                Pot++;
            }
            else
            {
                Console.WriteLine("Bad luck, you guessed wrong");
                Pot--;
            }

            currentNumber = nextNumber;
            Console.WriteLine($"The current number is {currentNumber}");
        }

        public static void Hint()
        {
            int half = MAXIMUM / 2;
            if (currentNumber >= half)
                Console.WriteLine($"The number is at least {half}");
            else Console.WriteLine($"The number is at most {half}");
            Pot--;
        }
    }
}
