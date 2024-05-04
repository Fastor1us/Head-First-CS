namespace PaintballGunConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfBalls = ReadInt(20, "Number of balls");
            int magazineSize = ReadInt(16, "Magazine size");

            Console.Write($"Loaded [false]: ");
            bool.TryParse(Console.ReadLine(), out bool isLoaded);

            PaintballGun gun = new(numberOfBalls, magazineSize, isLoaded);
            while (true)
            {
                Console.WriteLine($"{gun.Balls} balls, {gun.BallsLoaded} loaded");
                if (gun.IsEmpty()) Console.WriteLine("WARNING: You're out of ammo");
                Console.WriteLine("Space to shoot, r to reload, + to add ammo, q to quit");
                char key = char.ToLower(Console.ReadKey(true).KeyChar);
                if (key == ' ') Console.WriteLine($"Shooting returned {gun.Shoot()}");
                else if (key == 'r') gun.Reload();
                else if (key == '+') gun.Balls += gun.MagazineSize;
                else if (key == 'q') return;
            }

            int ReadInt(int value, string prompt)
            {
                // Вывести сообщение, за которым следует [значение по умолчанию]:
                Console.Write($"{prompt} [{value}]: ");
                // Прочитать строку из ввода и попытаться преобразовать ее вызовом int.TryParse
                string? str = Console.ReadLine();
                if (str != "" && int.TryParse(str, out value))
                    // Если преобразование прошло успешно, вывести на консоль строку " using value" + value.
                    Console.WriteLine(" using value " + value);
                else
                    // В противном случае вывести на консоль строку " using default value" + value
                    Console.WriteLine(" using default value " + value);

                return value;
            }
        }
    }
}
