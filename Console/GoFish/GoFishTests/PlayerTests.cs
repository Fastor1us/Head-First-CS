using GoFish.Classes;
using GoFish.Enums;
using GoFishTests.Utils;

namespace GoFishTests;

[TestClass]
public class PlayerTests
{
    private static bool CheckCardListEquality(IEnumerable<Card> listOfCard1, IEnumerable<Card> listOfCard2)
    {
        var deck1 = listOfCard1.Select(c => c.ToString()).ToList();
        var deck2 = listOfCard2.Select(c => c.ToString()).ToList();
        return deck1.Count == deck2.Count && deck1.All(c => deck2.Contains(c));
    }

    [TestMethod]
    public void TestGetNextHand()
    {
        var deck = new Deck(true);
        var player = new Player("Owen", []);

        player.GetNextHand(deck);
        var listedDeck = deck
            .Select(c => c.ToString())
            .ToList();
        var removedCardFromDeck = new Deck(true)
            .Where(c => !listedDeck.Contains(c.ToString()));
        var playerCards = player.Hand;

        Assert.IsTrue(CheckCardListEquality(removedCardFromDeck, playerCards));
    }

    [TestMethod]
    public void TestWithdrawValues()
    {
        IEnumerable<Card> cards =
        [
            new (Values.Jack, Suits.Spades),
            new (Values.Three, Suits.Clubs),
            new (Values.Three, Suits.Hearts),
            new (Values.Four, Suits.Diamonds),
            new (Values.Three, Suits.Diamonds),
            new (Values.Jack, Suits.Clubs),
        ];
        IEnumerable<Card> whatThreesWeShouldGet =
        [
            new (Values.Three, Suits.Clubs),
            new (Values.Three, Suits.Hearts),
            new (Values.Three, Suits.Diamonds),
        ];
        IEnumerable<Card> whatJacksWeShouldGet =
        [
            new (Values.Jack, Suits.Spades),
            new (Values.Jack, Suits.Clubs),
        ];

        var player = new Player("Owen", cards);
        var threes = player.WithdrawValues(Values.Three, new Deck(true));
        var jacks = player.WithdrawValues(Values.Jack, new Deck(true));
        var hand = player.Hand.Select(Card => Card.ToString()).ToList();

        Assert.IsTrue(CheckCardListEquality(whatThreesWeShouldGet, threes));
        Assert.IsTrue(CheckCardListEquality(whatJacksWeShouldGet, jacks));
        CollectionAssert.AreEqual(new List<string>() { "Four of Diamonds" }, hand);
        Assert.AreEqual("Owen has 1 card and 0 books", player.Status);
    }

    [TestMethod]
    public void TestAddCardsAndPullOutBooks()
    {
        IEnumerable<Card> cards =
        [
            new (Values.Three, Suits.Clubs),
            new (Values.Four, Suits.Diamonds),
            new (Values.Three, Suits.Hearts),
        ];
        IEnumerable<Card> cardsToAdd =
        [
            new (Values.Three, Suits.Diamonds),
            new (Values.Three, Suits.Spades),
        ];

        var player = new Player("Owen", cards);
        player.AddCards(cardsToAdd);
        player.PullOutBook();
        var books = player.Books.ToList();
        var hand = player.Hand.Select(Card => Card.ToString()).ToList();

        Assert.AreEqual(1, books.Count);
        CollectionAssert.AreEqual(new List<Values>() { Values.Three }, books);
        CollectionAssert.AreEqual(new List<string>() { "Four of Diamonds" }, hand);
        Assert.AreEqual("Owen has 1 card and 1 book", player.Status);
    }

    [TestMethod]
    public void TestDrawCard()
    {
        var player = new Player("Owen");
        var deck = new Deck(true);
        player.DrawCard(deck);

        Assert.AreEqual(1, player.Hand.Count());
        Assert.AreEqual("Ace of Diamonds", player.Hand.First().ToString());
        Assert.AreEqual("Two of Diamonds", deck.First().ToString());
    }

    [TestMethod]
    public void TestRandomValueFromHand()
    {
        var player = new Player("Owen", new Deck(true));

        Player.Random = new MockRandom() { ValueToReturn = 0 };
        Assert.AreEqual("Ace", player.RandomValueFromHand().ToString());

        Player.Random = new MockRandom() { ValueToReturn = 4 };
        Assert.AreEqual("Five", player.RandomValueFromHand().ToString());

        Player.Random = new MockRandom() { ValueToReturn = 8 };
        Assert.AreEqual("Nine", player.RandomValueFromHand().ToString());

        Player.Random = new Random();
    }
}
