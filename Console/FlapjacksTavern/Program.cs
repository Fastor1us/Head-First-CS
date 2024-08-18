namespace FlapjacksTavern
{
    internal class Program
    {
        static readonly Random random = new();
        static readonly Queue<Lumberjack> lumberjackQueue = new();

        static void Main(string[] args)
        {
            Console.WriteLine("Greeting, customer!");
            Console.WriteLine("Order flapjacks! Make a lumberjack queue!");
            Console.WriteLine("Now, now...");

            MakeQueue();

            while (lumberjackQueue.Count > 0)
                lumberjackQueue.Dequeue().EatFlapjacks();
        }

        static void MakeQueue()
        {
            while (true)
            {
                string name;
                do
                {
                    bool firstInQueue = lumberjackQueue.Count == 0;
                    string msgPrefix = firstInQueue ? "First" : "Next";
                    string msgSuffix = firstInQueue ? "" : " (blank to end)";
                    Console.Write($"{msgPrefix} lumberjack's name{msgSuffix}: ");
                    name = Console.ReadLine()!;
                    if (name == string.Empty || int.TryParse(name, out _))
                    {
                        if (name == string.Empty && !firstInQueue)
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Hey! Gemme a proper name!");
                            name = string.Empty;
                        }
                    }
                } while (string.IsNullOrEmpty(name));

                int numberOfFlapjacks;
                do
                {
                    Console.Write("Number of flapjacks: ");
                    string input = Console.ReadKey().KeyChar.ToString();
                    if (!int.TryParse(input, out numberOfFlapjacks))
                    {
                        Console.WriteLine("\nHey! Try it once again!");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                } while (numberOfFlapjacks == 0);

                Lumberjack lumberjack = new(name);
                for (int i = 0; i < numberOfFlapjacks; i++)
                {
                    int flapjackLength = Enum.GetValues(typeof(Flapjack)).Length;
                    lumberjack.TakeFlapjack((Flapjack)random.Next(flapjackLength));
                }
                lumberjackQueue.Enqueue(lumberjack);
            }
        }
    }
}
