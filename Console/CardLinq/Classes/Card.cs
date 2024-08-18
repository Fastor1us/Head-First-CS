namespace CardLinq.Classes;

class Card(Enums.Values value, Enums.Suits suit) : IComparable<Card>
{
    public Enums.Values Value { get; set; } = value;
    public Enums.Suits Suit { get; set; } = suit;

    public int CompareTo(Card? other)
    {
        return new CardComparerByValue().Compare(this, other);
    }

    public override string ToString() { return $"{Value} of {Suit}"; }

}
