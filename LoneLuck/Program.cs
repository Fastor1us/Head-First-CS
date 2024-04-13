namespace LoneLuck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double odds = .75;
            Random random = new Random();

            Player player = new Player(200);

            Console.WriteLine("Welcome to the casino. The odds are 0.75");

            while (player.GetCashInfo() > 0)
            {
                player.PrintCashBalance();
                Console.WriteLine("How much do you want to bet: ");
                string? bet = Console.ReadLine();
                if (
                    int.TryParse(bet, out int intBet) && 
                    intBet != 0 && intBet <= player.GetCashInfo()
                   )
                {
                    if (random.NextDouble() < odds)
                    {
                        Console.WriteLine("You win " + intBet * 2);
                        player.AddCash(intBet * 2);
                    }
                    else
                    {
                        Console.WriteLine("Bad luck, you lose.");
                        player.RemoveCash(intBet);
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
            Console.WriteLine("The house always wins.");
        }
    }
}
