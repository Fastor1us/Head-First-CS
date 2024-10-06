using GoFish.Classes;
using GoFish.Enums;

namespace GoFish;

public class GameController
{
    public static Random Random = new Random();
    private GameState gameState;
    public bool GameOver { get { return gameState.GameOver; } }
    public Player HumanPlayer { get { return gameState.HumanPlayer; } }
    public IEnumerable<Player> Opponents { get { return gameState.Opponents; } }
    public string Status { get; private set; }

    /// <summary>
    /// Constructs a new GameController
    /// </summary>
    /// <param name="humanPlayerName">Name of the human player</param>
    /// <param name="computerPlayerNames">Names of the computer players</param>
    public GameController(string humanPlayerName, IEnumerable<string> computerPlayerNames)
    {
        Init(humanPlayerName, computerPlayerNames);
    }

    private void Init(string humanPlayerName, IEnumerable<string> computerPlayerNames)
    {
        gameState = new(humanPlayerName, computerPlayerNames, new Deck(true));
        Status = $"Starting a new game with players {HumanPlayer}, {string.Join(", ", Opponents)}";
    }

    /// <summary>
    /// Plays the next round, ending the game if everyone ran out of cards
    /// </summary>
    /// <param name="playerToAsk">Which player the human is asking for a card</param>
    /// <param name="valueToAskFor">The value of the card the human is asking for</param>
    public void NextRound(Player playerToAsk, Values valueToAskFor)
    {
        Status = string.Empty;

        Status += gameState.PlayRound(HumanPlayer, playerToAsk, valueToAskFor, gameState.Stock);

        ComputerPlayersPlayNextRound();

        foreach (Player player in new[] { HumanPlayer }.Concat(Opponents))
        {
            Status += Environment.NewLine;
            Status += $"{player.Name} has {player.Hand.Count()} card{Player.S(player.Hand.Count())}";
            Status += $" and {player.Books.Count()} book{Player.S(player.Books.Count())}";
        }
        Status += Environment.NewLine;
        Status += $"The stock has {gameState.Stock.Count()} card{Player.S(gameState.Stock.Count())}";
        Status += Environment.NewLine;
    }

    /// <summary>
    /// All of the computer players that have cards play the next round. If the human is
    /// out of cards, then the deck is depleted and they play out the rest of the game.
    /// </summary>
    public void ComputerPlayersPlayNextRound()
    {
        foreach (Player player in Opponents)
        {
            if (player.Hand.Any())
            {
                Status += Environment.NewLine;
                Status += gameState.PlayRound(
                    player,
                    gameState.RandomPlayer(player),
                    player.RandomValueFromHand(),
                    gameState.Stock
                );
            }
        }
    }

    /// <summary>
    /// Starts a new game with the same player names
    /// </summary>
    public void NewGame()
    {
        Init(HumanPlayer.Name, Opponents.Select(p => p.Name));
    }

    /// <summary>
    /// Checks for a winner by seeing if any players have any cards left,
    /// sets GameOver if the game is over and there's a winner
    /// </summary>
    /// <returns>A string with the winners, or a null value if there are no winners</returns>
    public string? CheckForWinner()
    {
        return gameState.CheckForWinner();
    }
}
