namespace AbilityScoreTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AbilityScoreCalculator calculator = new AbilityScoreCalculator();

            while (true)
            {
                calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll");
                calculator.DivideBy = ReadDouble(calculator.DivideBy, "Divide by");
                calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
                calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
                calculator.CalculateAbilityScore();
                Console.WriteLine("Calculated ability score: " + calculator.Score);
                Console.WriteLine("Press Q to quit, any other key to continue");
                char keyChar = Console.ReadKey(true).KeyChar;
                if (char.ToUpper(keyChar) == 'Q') return;
            }
        }

        /// <summary>
        /// Выводит сообщение и читает значение int с консоли.
        /// </summary>
        /// <param name="value">Значение по умолчанию.</param>
        /// <param name="prompt">Сообщение, выводимое на консоль.</param>
        /// <returns>Прочитанное значение int или значение по умолчанию, если преобразование 
        /// невозможно.</returns>
        private static int ReadInt(int value, string prompt)
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

        /// <summary>
        /// Выводит сообщение и читает значение double с консоли.
        /// </summary>
        /// <param name="value">Значение по умолчанию.</param>
        /// <param name="prompt">Сообщение, выводимое на консоль.</param>
        /// <returns>Прочитанное значение double или значение по умолчанию, если преобразование 
        /// невозможно.</returns>
        private static double ReadDouble(double value, string prompt)
        {
            // Вывести сообщение, за которым следует [значение по умолчанию]:
            Console.Write($"{prompt} [{value}]: ");
            // Прочитать строку из ввода и попытаться преобразовать ее вызовом double.TryParse
            string? str = Console.ReadLine();
            if (str != "" && double.TryParse(str, out value))
                // Если преобразование прошло успешно, вывести на консоль строку " using value" + value.
                Console.WriteLine(" using value " + value);
            else
                // В противном случае вывести на консоль строку " using default value" + value
                Console.WriteLine(" using default value " + value);

            return value;
        }
    }
}
