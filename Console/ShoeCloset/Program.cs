namespace ShoeCloset;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            if (Classes.ShoeCloset.ShoeCount == 0)
            {
                Console.WriteLine("The shoe closet is empty.\n");
                Classes.ShoeCloset.Add();
            }
            else
            {
                Classes.ShoeCloset.PrintShoes();
                Console.WriteLine();

                bool isChosen = false;
                do
                {
                    Console.Write("Press 'a' to add or 'r' to remove a shoe:");
                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.WriteLine();
                    if (key.Key == ConsoleKey.A)
                    {
                        Classes.ShoeCloset.Add();
                        isChosen = true;
                    }
                    else if (key.Key == ConsoleKey.R)
                    {
                        Classes.ShoeCloset.Remove();
                        isChosen = true;
                    }
                    else
                    {
                        Console.WriteLine(Constants.WRONG_INPUT);
                    }
                } while (!isChosen);
                Console.WriteLine();
            }
        }
    }
}
