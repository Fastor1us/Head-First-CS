using JimmyLinq.Enums;

namespace JimmyLinq.Classes;

public static class ComicAnalyzer
{
    private static PriceRange CalculatePriceRange(Comic comic, IReadOnlyDictionary<int, decimal> prices)
    {
        return prices[comic.Issue] < 100 ? PriceRange.Cheap : PriceRange.Expensive;
    }

    public static IEnumerable<IGrouping<PriceRange, Comic>> 
        GroupComicsByPrice(IEnumerable<Comic> comics, IReadOnlyDictionary<int, decimal> prices)
    {
        return
           from comic in comics
           orderby prices[comic.Issue]
           group comic by CalculatePriceRange(comic, prices) into priceGroup
           select priceGroup;
    }

    public static IEnumerable<string> GetReviews(IEnumerable<Comic> comics, IEnumerable<Review> reviews)
    {
        return
            from comic in comics
            orderby comic.Issue
            join review in reviews
            on comic.Issue equals review.Issue
            select $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}";
    }
}
