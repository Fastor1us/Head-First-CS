using System.Collections;

namespace CardLinq.Classes;

class Deck : IEnumerable<Card>
{
    private readonly Random random = new();
    private List<Card> cards = [];

    public Deck()
    {
        for (int suit = 0; suit <= 3; suit++)
        {
            for (int value = 1; value <= 13; value++)
            {
                cards.Add(new Card((Enums.Values)value, (Enums.Suits)suit));
            }
        }
    }

    public Deck ShuffleDeck()
    {
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            (cards[n], cards[k]) = (cards[k], cards[n]);
        }
        return this;
    }

    public Deck SortBySuit()
    {
        cards = [.. cards.OrderBy(card => card.Suit)];
        return this;
    }

    public Deck SortByValue()
    {
        cards = [.. cards.OrderBy(card => card.Value)];
        return this;
    }

    public Deck SortBySuitAndValue()
    {
        List<Card> sortedCards = [];
        foreach (var suit in Enum.GetValues(typeof(Enums.Suits)))
        {
            var suitCards = cards.Where(c => c.Suit == (Enums.Suits)suit).OrderBy(c => c.Value);
            foreach (var suitCard in suitCards)
            {
                sortedCards.Add(suitCard);
            }
        }
        cards = [.. sortedCards];
        return this;
    }

    public Deck PrintCards()
    {
        for (int i = 0; i < cards.Count; i++)
            Console.WriteLine(cards[i]);
        return this;
    }

    public IEnumerator<Card> GetEnumerator()
    {
        //return cards.GetEnumerator();
        foreach (Card card in cards) yield return card;
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
