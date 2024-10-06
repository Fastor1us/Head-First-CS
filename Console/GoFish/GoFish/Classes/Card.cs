namespace GoFish.Classes;

public class Card(Enums.Values value, Enums.Suits suit) : IComparable<Card>
{
    public Enums.Values Value { get; set; } = value;
    public Enums.Suits Suit { get; set; } = suit;

    public int CompareTo(Card? other)
    {
        //return Compare(this, other);
        return new CardComparerByValue().Compare(this, other);
    }
    //private static int Compare(Card? x, Card? y)
    //{
    //    if (x == null || y == null)
    //        return 1;
    //    if (x.Value < y.Value)
    //        return -1;
    //    if (x.Value > y.Value)
    //        return 1;
    //    return 0;
    //}

    public override string ToString() { return $"{Value} of {Suit}"; }
}

class CardComparerByValue : IComparer<Card>
{
    public int Compare(Card? x, Card? y)
    {
        if (x == null || y == null)
            return 1;
        if (x.Value < y.Value)
            return -1;
        if (x.Value > y.Value)
            return 1;
        return 0;
    }
}