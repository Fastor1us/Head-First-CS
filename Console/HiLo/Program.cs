namespace HiLo;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to HiLo");
        Console.Write("You are guessing whether the next number will be ");
        Console.WriteLine("higher or lower than the current one");
        Console.WriteLine($"Guess numbers between 1 and {HiLoGame.MAXIMUM}");
        HiLoGame.Hint();
        while (HiLoGame.Pot > 0)
        {
            Console.Write("Press h for higher, l for lower, ? to buy a hint,");
            Console.Write($" or any other key to quit with {HiLoGame.Pot}\n");
            char key = char.ToLower(Console.ReadKey(true).KeyChar);
            if (key == 'h') HiLoGame.Guess(true);
            else if (key == 'l') HiLoGame.Guess(false);
            else if (key == '?') HiLoGame.Hint();
            else
            {
                Console.WriteLine($"You exit with {HiLoGame.Pot} points");
                return;
            }
        }
        Console.WriteLine("The pot is empty. Bye!");
    }
}
