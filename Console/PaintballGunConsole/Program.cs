namespace PaintballGunConsole;

internal class Program
{
    static void Main(string[] args)
    {
        int numberOfBalls = ReadInt(20, "Number of balls");
        int magazineSize = ReadInt(16, "Magazine size");

        Console.Write($"Loaded [false]: ");
        _ = bool.TryParse(Console.ReadLine(), out bool isLoaded);

        PaintballGun gun = new(numberOfBalls, magazineSize, isLoaded);
        while (true)
        {
            int freeBalls = gun.Balls - gun.BallsLoaded > 0 ? gun.Balls - gun.BallsLoaded : 0;
            Console.WriteLine($"Free balls: {freeBalls}; Gun loaded with {gun.BallsLoaded} balls");
            if (gun.IsEmpty()) Console.WriteLine("WARNING: You're out of ammo");
            Console.WriteLine("Space to shoot, r to reload, + to add ammo, q to quit");
            char key = char.ToLower(Console.ReadKey(true).KeyChar);
            if (key == ' ') Console.WriteLine($"Shooting returned {gun.Shoot()}");
            else if (key == 'r') gun.Reload();
            else if (key == '+') gun.Balls += gun.MagazineSize;
            else if (key == 'q') return;
        }
    }

    /// <summary>
    /// Выводит сообщение и читает значение int с консоли.
    /// </summary>
    /// <param name="defaultValue">Значение по умолчанию.</param>
    /// <param name="prompt">Сообщение, выводимое на консоль.</param>
    /// <returns>Прочитанное значение int или значение по умолчанию, если преобразование 
    /// невозможно.</returns>
    private static int ReadInt(int defaultValue, string prompt)
    {
        Console.Write($"{prompt} [{defaultValue}]: ");
        string? str = Console.ReadLine();
        int resValue = int.TryParse(str, out resValue) ? resValue : defaultValue;
        Console.WriteLine($" using {(defaultValue == resValue ? "default" : "")} value {resValue}");
        return defaultValue;
    }
}
