using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections;
using GoFish.Enums;

namespace GoFish.Classes;

public class Deck : INotifyPropertyChanged, IEnumerable<Card>
{
    private readonly Random random = Player.Random;

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<Card> Cards { get; private set; } = [];

    public Deck(bool fillDeck)
    {
        if (fillDeck) FillDeck();
    }

    public void FillDeck()
    {
        for (int suit = 0; suit <= 3; suit++)
            for (int value = 1; value <= 13; value++)
                Cards.Add(new Card((Values)value, (Suits)suit));
    }

    public void Add(Card card) => Cards.Add(card);

    public void Add(Values value, Suits suit) => Cards.Add(new Card(value, suit));

    public void Remove(int index) => Cards.RemoveAt(index);

    public void Remove(Card card) => Remove(card.Value, card.Suit);

    public void Remove(Values value, Suits suit)
    {
        var cardsToRemove = Cards.Where(x => x.Value == value && x.Suit == suit).ToList();
        foreach (var card in cardsToRemove) Cards.Remove(card);
    }

    public Card? DrawCard()
    {
        if (Cards.Count == 0)
        {
            return null;
        }
        else
        {
            var card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }
    }

    public void ShuffleDeck()
    {
        int n = Cards.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            (Cards[n], Cards[k]) = (Cards[k], Cards[n]);
        }
    }

    public void SortBySuit()
    {
        Cards = [.. Cards.OrderBy(card => card.Suit)];
    }

    public void SortByValue()
    {
        Cards = [.. Cards.OrderBy(card => card.Value)];
    }

    public void SortBySuitAndValue()
    {
        List<Card> sortedCards = [];
        foreach (var suit in Enum.GetValues(typeof(Suits)))
        {
            var suitCards = Cards.Where(c => c.Suit == (Suits)suit).OrderBy(c => c.Value);
            foreach (var suitCard in suitCards) sortedCards.Add(suitCard);
        }
        Cards.Clear();
        foreach (var card in sortedCards) Cards.Add(card);
    }

    public void PrintCards()
    {
        for (int i = 0; i < Cards.Count; i++) Console.WriteLine(Cards[i]);
    }

    public void Reset()
    {
        Cards.Clear();
        FillDeck();
    }

    public void Clear() => Cards.Clear();

    public IEnumerator<Card> GetEnumerator()
    {
        foreach (Card card in Cards) yield return card;
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}