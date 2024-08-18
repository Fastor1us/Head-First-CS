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

        /// <summary>
        /// Выводит сообщение и читает значение double с консоли.
        /// </summary>
        /// <param name="value">Значение по умолчанию.</param>
        /// <param name="prompt">Сообщение, выводимое на консоль.</param>
        /// <returns>Прочитанное значение double или значение по умолчанию, если преобразование 
        /// невозможно.</returns>
        private static double ReadDouble(double defaultValue, string prompt)
        {
            Console.Write($"{prompt} [{defaultValue}]: ");
            string? str = Console.ReadLine();
            double resValue = double.TryParse(str, out resValue) ? resValue : defaultValue;
            Console.WriteLine($" using {(defaultValue == resValue ? "default" : "")} value {resValue}");
            return defaultValue;
        }
    }
}
