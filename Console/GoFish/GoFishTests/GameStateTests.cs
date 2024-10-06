using GoFish.Classes;
using GoFish.Enums;
using GoFishTests.Utils;

namespace GoFishTests;

[TestClass]
public class GameStateTests
{
    [TestMethod]
    public void TestConstructor()
    {
        string playerName = "Player";
        IEnumerable<string> opponentNames = ["First", "Second", "Third", "Fourth"];
        var deck = new Deck(true);
        GameState gameState = new(playerName, opponentNames, deck);

        Assert.AreEqual(27, gameState.Stock.Cards.Count);
        Assert.AreEqual("Player", gameState.HumanPlayer.Name);
        Assert.AreEqual(5, gameState.HumanPlayer.Hand.Count());
        for (int i = 0; i < gameState.Opponents.Count(); i++)
        {
            Assert.AreEqual(opponentNames.ToList()[i], gameState.Opponents.ToList()[i].Name);
            Assert.AreEqual(5, gameState.Opponents.ToList()[i].Hand.Count());
        }
    }

    [TestMethod]
    public void TestRandomPlayer()
    {
        string playerName = "Player";
        IEnumerable<string> opponentNames = ["First", "Second", "Third", "Fourth"];
        var deck = new Deck(true);
        GameState gameState = new(playerName, opponentNames, deck);

        Player.Random = new MockRandom() { ValueToReturn = 1 };
        Assert.AreEqual("Second", gameState.RandomPlayer(gameState.Players.ToList()[0]).Name);

        Player.Random = new MockRandom() { ValueToReturn = 0 };
        Assert.AreEqual("Player", gameState.RandomPlayer(gameState.Players.ToList()[1]).Name);

        Assert.AreEqual("First", gameState.RandomPlayer(gameState.Players.ToList()[0]).Name);

        Player.Random = new Random();
    }

    [TestMethod]
    public void TestPlayRound()
    {
        var deck = new Deck(false);

        List<Card> cardsToAdd = [
            // Cards the game will deal to Owen
            new (Values.Jack, Suits.Spades),
            new (Values.Jack, Suits.Hearts),
            new (Values.Six, Suits.Spades),
            new (Values.Jack, Suits.Diamonds),
            new (Values.Six, Suits.Hearts),
            // Cards the game will deal to Brittney
            new (Values.Six, Suits.Diamonds),
            new (Values.Six, Suits.Clubs),
            new (Values.Seven, Suits.Spades),
            new (Values.Jack, Suits.Clubs),
            new (Values.Nine, Suits.Spades),
            // Two more cards in the deck for Owen to draw when he runs out
            new (Values.Queen, Suits.Hearts),
            new (Values.King, Suits.Spades),
        ];

        var gameState = new GameState("Owen", ["Brittney"], deck);
        foreach (var card in cardsToAdd) gameState.Stock.Add(card);

        var owen = gameState.HumanPlayer;
        var brittney = gameState.Opponents.First();

        owen.GetNextHand(gameState.Stock);
        brittney.GetNextHand(gameState.Stock);

        Assert.AreEqual("Owen", owen.Name);
        Assert.AreEqual(5, owen.Hand.Count());
        Assert.AreEqual("Brittney", brittney.Name);
        Assert.AreEqual(5, brittney.Hand.Count());

        var message = gameState.PlayRound(owen, brittney, Values.Jack, deck);
        Assert.AreEqual(
            "Owen asked Brittney for Jacks" + Environment.NewLine + "Brittney has 1 Jack card",
            message
        );
        Assert.AreEqual(1, owen.Books.Count());
        Assert.AreEqual(2, owen.Hand.Count());
        Assert.AreEqual(0, brittney.Books.Count());
        Assert.AreEqual(4, brittney.Hand.Count());

        message = gameState.PlayRound(brittney, owen, Values.Six, deck);
        Assert.AreEqual(
            "Brittney asked Owen for Sixes" + Environment.NewLine + "Owen has 2 Six cards",
            message
        );
        Assert.AreEqual(1, owen.Books.Count());
        Assert.AreEqual(2, owen.Hand.Count());
        Assert.AreEqual(1, brittney.Books.Count());
        Assert.AreEqual(2, brittney.Hand.Count());

        message = gameState.PlayRound(owen, brittney, Values.Queen, deck);
        Assert.AreEqual(
            "Owen asked Brittney for Queens" + Environment.NewLine + "The stock is out of cards",
            message
        );
        Assert.AreEqual(1, owen.Books.Count());
        Assert.AreEqual(2, owen.Hand.Count());
    }

    [TestMethod]
    public void TestCheckForWinner()
    {
        var deck = new Deck(false);

        List<Card> cardsToAdd = [
            // Cards the game will deal to Owen
            new (Values.Ace, Suits.Spades),
            new (Values.Ace, Suits.Hearts),
            new (Values.Ace, Suits.Clubs),
            new (Values.Ace, Suits.Diamonds),
            new (Values.Two, Suits.Diamonds),
            new (Values.Two, Suits.Clubs),
            new (Values.Two, Suits.Spades),
            new (Values.Two, Suits.Hearts),
            // Cards the game will deal to Brittney
            new (Values.Three, Suits.Diamonds),
            new (Values.Three, Suits.Clubs),
            new (Values.Three, Suits.Spades),
            new (Values.Three, Suits.Hearts),
            new (Values.Four, Suits.Diamonds),
            new (Values.Four, Suits.Clubs),
            new (Values.Four, Suits.Spades),
            new (Values.Four, Suits.Hearts),
        ];

        var gameState = new GameState("Owen", ["Brittney"], deck);
        var owen = gameState.HumanPlayer;
        var brittney = gameState.Opponents.First();
        Assert.AreEqual(
            "The winners are Owen, Brittney!" + Environment.NewLine + "Each of them is having 0 books",
            gameState.CheckForWinner()
        );

        owen.AddCards(cardsToAdd.GetRange(0, 8));
        brittney.AddCards(cardsToAdd.GetRange(8, 4));
        Assert.AreEqual(null, gameState.CheckForWinner());

        owen.PullOutBook();
        owen.PullOutBook();
        brittney.PullOutBook();
        Assert.AreEqual(2, owen.Books.Count());
        Assert.AreEqual(1, brittney.Books.Count());
        Assert.AreEqual("The winner is Owen! Owen has 2 books", gameState.CheckForWinner());

        brittney.AddCards(cardsToAdd.Skip(12));
        brittney.PullOutBook();
        Assert.AreEqual(
            "The winners are Owen, Brittney!" + Environment.NewLine + "Each of them is having 2 books",
            gameState.CheckForWinner()
        );
    }
}
