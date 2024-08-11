namespace ShoeCloset.Classes;

internal static class ShoeCloset
{
    private static readonly List<Shoe> shoes = [];
    public static int ShoeCount { get { return shoes.Count; } }

    public static void Add()
    {
        Console.WriteLine("Adding a shoe...");

        Enums.Shoes shoe = ChooseFromEnum<Enums.Shoes>("Enter a style: ");
        Enums.Colors color = ChooseFromEnum<Enums.Colors>("Enter the color: ");

        shoes.Add(new Classes.Shoe(shoe, color));
        Console.WriteLine();
    }

    private static T ChooseFromEnum<T>(string msgBeforeInput) where T : Enum
    {
        int input = 0;
        bool isValidInput = false;
        while (!isValidInput)
        {
            for (int i = 0; i < (Enum.GetValues(typeof(T))).Length; i++)
            {
                Console.WriteLine($"Press {i} to add a {(T)Enum.ToObject(typeof(T), i)}");
            }
            Console.Write(msgBeforeInput);
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            if (int.TryParse(key.KeyChar.ToString(), out input) && Enum.IsDefined(typeof(T), input))
                isValidInput = true;
            else
                Console.WriteLine(Constants.WRONG_INPUT);
        }
        return (T)Enum.ToObject(typeof(T), input);
    }

    public static void Remove()
    {
        bool isValidInput = false;
        while (!isValidInput)
        {
            Console.Write("Enter the number of the shoe to remove: ");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            if (int.TryParse(key.KeyChar.ToString(), out int input) && input > 0 && input < shoes.Count + 1)
            {
                isValidInput = true;
                shoes.RemoveAt(input - 1);
            }
            else
            {
                Console.WriteLine(Constants.WRONG_INPUT);
                PrintShoes();
            }
        }
    }

    public static void PrintShoes()
    {
        Console.WriteLine("The shoe closet contains:");
        for (int i = 0; i < shoes.Count; i++)
        {
            Console.WriteLine($"Shoe #{i + 1}: {shoes[i].Name}");
        }
    }
}
