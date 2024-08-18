using System.Collections;

namespace LinqTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = [];
            for (int i = 1; i <= 99; i++) numbers.Add(i);
            IEnumerable<int> firstAndLastFive = numbers.Take(5).Concat(numbers.TakeLast(5));
            Print(firstAndLastFive.ToArray());

            int[] values = [0, 12, 44, 36, 92, 54, 13, 8];
            IEnumerable<int> result = from v in values where v < 37 orderby -v select v;
            Print(values);

            int[] sequence = [5, 10, 25];
            DoubleNumbers doubledNumbers = new(sequence);
            Print(doubledNumbers);
        }

        private static void Print(IEnumerable arr)
        {
            foreach (int item in arr) Console.Write($"{item} ");
            Console.WriteLine();
        }
    }

    class DoubleNumbers(int[] numbers) : IEnumerable<int>
    {
        private int[] Numbers => numbers;

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Numbers.Length; i++)
            {
                yield return Numbers[i] * 2;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
