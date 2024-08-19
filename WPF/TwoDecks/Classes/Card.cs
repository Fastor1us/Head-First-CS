namespace TwoDecks;

class Card(Values value, Suits suit)
{
    public Values Value { get; } = value;
    public Suits Suit { get; } = suit;

    public override string ToString() => $"{Value} of {Suit}";
}