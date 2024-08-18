using CardLinq.Classes;

namespace CardLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Card> cards = new Deck()
                .ShuffleDeck()
                .Take(16);

            // синтаксис декларативных запросов LINQ
            //var grouped =
            //    from card in cards
            //    group card by card.Suit into suitGroup
            //    orderby suitGroup.Key descending
            //    select suitGroup;

            // синтаксис сцеплённых вызовов методов LINQ
            var grouped =
                cards
                .GroupBy(card => card.Suit)
                .OrderByDescending(group => group.Key);

            foreach (var group in grouped)
                Console.WriteLine($@"Group: {group.Key}
Count: {group.Count()}
Minimum: {group.Min()}
Maximum: {group.Max()}");
        }
    }
}
