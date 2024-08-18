namespace ComicsShelf;

internal class Program
{
    static void Main(string[] args)
    {
        IEnumerable<Comic> mostExpensive =
            from comic in Comic.Catalog
            where Comic.Prices[comic.Issue] > 500
            orderby Comic.Prices[comic.Issue] descending
            select comic;
        foreach (Comic comic in mostExpensive)
            Console.WriteLine($"{comic} is worth {Comic.Prices[comic.Issue]:c}");

        var mostExpensive2 =
           from comic in Comic.Catalog
           where Comic.Prices[comic.Issue] > 500
           orderby Comic.Prices[comic.Issue] descending
           select $"{comic} is worth {Comic.Prices[comic.Issue]:c}";
        foreach (string comic in mostExpensive2)
            Console.WriteLine(comic);
    }
}
