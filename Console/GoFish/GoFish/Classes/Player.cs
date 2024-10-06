using GoFish.Enums;

namespace GoFish.Classes;

public class Player
{
    public static Random Random = new();
    private readonly List<Card> hand = [];
    private readonly List<Values> books = [];

    public IEnumerable<Card> Hand => hand;

    public IEnumerable<Values> Books => books;

    public readonly string Name;

    public static string S(int s) => s != 1 ? "s" : "";

    public string Status => $"{Name} {(Name == "You" ? "have" : "has")} {hand.Count} card{S(hand.Count)} and {books.Count} book{S(books.Count)}";

    public Player(string name) => Name = name;

    public Player(string name, IEnumerable<Card> cards)
    {
        Name = name;
        hand.AddRange(cards);
    }

    public void GetNextHand(Deck stock)
    {
        while ((stock.Cards.Count > 0) && (hand.Count < 5))
        {
            var card = stock.DrawCard();
            if (card != null) hand.Add(card);
            else return;
        }
    }

    public IEnumerable<Card> WithdrawValues(Values value, Deck deck)
    {
        var matchingCards = hand.Where(card => card.Value == value).ToList();
        hand.RemoveAll(card => card.Value == value);
        if (hand.Count == 0) GetNextHand(deck);
        return matchingCards;
    }

    public void AddCards(IEnumerable<Card> cards)
    {
        hand.AddRange(cards);
    }

    public void PullOutBook()
    {
        var keys = hand
            .GroupBy(card => card.Value)
            .Where(group => group.Count() == 4)
            .Select(group => group.Key);

        if (keys.Any())
        {
            var key = keys.First();
            hand.RemoveAll(card => card.Value == key);
            books.Add(key);
        }
    }

    public void DrawCard(Deck stock)
    {
        if (stock.Cards.Count > 0)
        {
            var card = stock.DrawCard();
            if (card != null) hand.Add(card);
        }
    }

    public Values RandomValueFromHand() => hand[Random.Next(hand.Count)].Value;
    public override string ToString() => Name;
}
