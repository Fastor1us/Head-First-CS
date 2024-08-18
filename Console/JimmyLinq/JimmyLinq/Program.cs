using JimmyLinq.Classes;

namespace JimmyLinq;

internal class Program
{
    static void Main(string[] args)
    {
        bool done = false;
        while (!done)
        {
            Console.WriteLine(@"
Press G to group comics by price, R to get reviews, any other key to quit");
            Console.WriteLine();
            switch (Console.ReadKey(true).KeyChar.ToString().ToUpper())
            {
                case "G":
                    GroupComicsByPrice();
                    break;
                case "R":
                    GetReviews();
                    break;
                default:
                    done = true;
                    break;
            }
        }
    }
    private static void GroupComicsByPrice()
    {
        var groups = ComicAnalyzer.GroupComicsByPrice(Comic.comic, Comic.Prices);
        foreach (var group in groups)
        {
            Console.WriteLine($"{group.Key} comics:");
            foreach (var comic in group)
                Console.WriteLine($"#{comic.Issue} {comic.Name}: {Comic.Prices[comic.Issue]:c}");
        }
    }
    private static void GetReviews()
    {
        var revies = ComicAnalyzer.GetReviews(Comic.comic, Comic.Reviews);
        Console.WriteLine("Reviews:");
        foreach (var review in revies)
            Console.WriteLine(review);
    }
}
