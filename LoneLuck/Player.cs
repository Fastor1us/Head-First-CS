namespace LoneLuck
{
    internal class Player
    {
        private int Cash { get; set; }

        public Player()
        {
            Cash = 100;
        }

        public Player(int cash)
        {
            if (cash > 0) Cash = cash;
            else Cash = 100;
        }

        public int GetCashInfo() { return Cash; }

        public void PrintCashBalance()
        {
            Console.WriteLine("The player has " + Cash);
        }

        public void RemoveCash(int amount)
        {
            if (amount > 0 && amount <= Cash) Cash -= amount;
        }

        public void AddCash(int amount)
        {
            if (amount > 0) Cash += amount;
        }
    }
}
