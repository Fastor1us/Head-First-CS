namespace Closure
{
    internal class Program
    {
        static Func<int> CreateSquare()
        {
            int x = 2;
            return () => ++x * x;
        }

        static void Main(string[] args)
        {
            Func<int> square = CreateSquare();

            Console.WriteLine(square());
            Console.WriteLine(square());
            Console.WriteLine(square());
        }
    }
}
