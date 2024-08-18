using SC = ShoeCloset.Classes.ShoeCloset;

namespace ShoeCloset;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            if (SC.ShoeCount == 0)
            {
                Console.WriteLine("The shoe closet is empty.\n");
                SC.Add();
            }
            else
            {
                SC.PrintShoes();
                Console.WriteLine();

                bool isChosen = false;
                do
                {
                    Console.Write("Press 'a' to add, 'r' to remove");
                    Console.Write(" a shoe and 'q' to quit:\n");
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    Console.WriteLine();
                    switch (key.Key)
                    {
                        case ConsoleKey.A:
                            SC.Add();
                            isChosen = true;
                            break;
                        case ConsoleKey.R:
                            SC.Remove();
                            isChosen = true;
                            break;
                        case ConsoleKey.Q:
                            Console.WriteLine("Goodbye!");
                            return;
                        default:
                            Console.WriteLine(Constants.WRONG_INPUT);
                            break;
                    }
                } while (!isChosen);
                Console.WriteLine();
            }
        }
    }
}
