namespace TwoDecks
{
    class Card
    {
        public Values Value { get; }
        public Suits Suit { get; }
        public Card(Values value, Suits suit)
        {
            Value = value;
            Suit = suit;
        }
        public override string ToString() { return $"{Value} of {Suit}"; }
    }
}