using GoFish;
using GoFish.Classes;
using GoFish.Enums;
using GoFishTests.Utils;

namespace GoFishTests;

[TestClass]
public class GameControllerTests
{
    [TestInitialize]
    public void Initialize()
    {
        Player.Random = new MockRandom() { ValueToReturn = 0 };
    }

    [TestMethod]
    public void TestConstructor()
    {
        var gameController = new GameController("Human", ["Player1", "Player2"]);
        Assert.AreEqual("Starting a new game with players Human, Player1, Player2", gameController.Status);
    }

    [TestMethod]
    public void TestNextRound()
    {
        // The constructor shuffles the deck, but MockRandom makes sure it stays almost in the same
        // order so Owen should have 2 to 6 of Diamonds, Brittney should have 7 to Jack of Diamonds
        var gameController = new GameController("Owen", ["Brittney"]);
        gameController.NextRound(gameController.Opponents.First(), Values.Seven);
        Assert.AreEqual(
            "Owen asked Brittney for Sevens" +
            Environment.NewLine + "Brittney has 1 Seven card" +
            Environment.NewLine + "Brittney asked Owen for Eights" +
            Environment.NewLine + "Brittney drew a card from the stock" +
            Environment.NewLine + "Owen has 6 cards and 0 books" +
            Environment.NewLine + "Brittney has 5 cards and 0 books" +
            Environment.NewLine + "The stock has 41 cards" +
            Environment.NewLine,
            gameController.Status
        );
    }

    [TestMethod]
    public void TestNewGame()
    {
        var gameController = new GameController("Owen", ["Brittney"]);
        gameController.NextRound(gameController.Opponents.First(), Values.Seven);
        gameController.NewGame();
        Assert.AreEqual("Owen", gameController.HumanPlayer.Name);
        Assert.AreEqual("Brittney", gameController.Opponents.First().Name);
        Assert.AreEqual("Starting a new game with players Owen, Brittney", gameController.Status);
    }

    /// <summary>
    /// Return Player.Random to normal behaviour (after we Mocking it)
    /// </summary>
    [TestMethod]
    public void RestorePlayerRandom()
    {
        Player.Random = new Random();
        Assert.IsTrue(true);
    }
}
