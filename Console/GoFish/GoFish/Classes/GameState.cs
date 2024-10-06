using GoFish.Enums;

namespace GoFish.Classes;

public class GameState
{
    public readonly IEnumerable<Player> Players;
    public readonly IEnumerable<Player> Opponents;
    public readonly Player HumanPlayer;
    public bool GameOver { get; private set; } = false;
    public readonly Deck Stock;

    /// <summary>
    /// Constructor creates the players and deals their first hands
    /// </summary>
    /// <param name="humanPlayerName">Name of the human player</param>
    /// <param name="opponentNames">Names of the computer players</param>
    /// <param name="stock">Stock of cards to deal from</param>
    public GameState(string humanPlayerName, IEnumerable<string> opponentNames, Deck stock)
    {
        Stock = stock;
        Stock.ShuffleDeck();

        HumanPlayer = new(humanPlayerName);
        HumanPlayer.GetNextHand(Stock);

        List<Player> opponents = [];
        foreach (var opponentName in opponentNames)
        {
            opponents.Add(new (opponentName));
            opponents[^1].GetNextHand(Stock);
        }
        Opponents = opponents;
        Players = new[] { HumanPlayer }.Concat(Opponents);

        foreach (var player in Players) player.PullOutBook();
    }

    /// <summary>
    /// Gets a random player that doesn't match the current player
    /// </summary>
    /// <param name="currentPlayer">The current player</param>
    /// <returns>A random player that the current player can ask for a card</returns>
    public Player RandomPlayer(Player currentPlayer) =>
        Players
            .Where(player => player != currentPlayer)
            .Where(player => player.Hand.Any())
            .Skip(Player.Random.Next(Players.Count() - 1))
            .First();

    /// <summary>
    /// Makes one player play a round
    /// </summary>
    /// <param name="player">The player asking for a card</param>
    /// <param name="playerToAsk">The player being asked for a card</param>
    /// <param name="valueToAskFor">The value to ask the player for</param>
    /// <param name="stock">The stock to draw cards from</param>
    /// <returns>A message that describes what just happened</returns>
    public string PlayRound(Player player, Player playerToAsk, Values valueToAskFor, Deck stock)
    {
        var valuePlural = (valueToAskFor == Values.Six) ? "Sixes" : $"{valueToAskFor}s";
        string roundInfo = $"{player.Name} asked {playerToAsk.Name} for {valuePlural}";
        roundInfo += Environment.NewLine;

        var receivedCards = playerToAsk.WithdrawValues(valueToAskFor, stock);

        if (receivedCards.Any())
        {
            roundInfo += $"{playerToAsk.Name} has {receivedCards.Count()} {valueToAskFor} card{Player.S(receivedCards.Count())}";
            player.AddCards(receivedCards);
        }
        else
        {
            Card? cardFromStack = Stock.DrawCard();

            if (cardFromStack != null)
            {
                roundInfo += $"{player.Name} drew a card from the stock";
                player.AddCards([cardFromStack]);
            }
            else
                roundInfo += "The stock is out of cards";
        }

        player.PullOutBook();

        return roundInfo;
    }

    /// <summary>
    /// Checks for a winner by seeing if any players have any cards left,
    /// sets GameOver if the game is over and there's a winner
    /// </summary>
    /// <returns>A string with the winners, or a null value if there are no winners</returns>
    public string? CheckForWinner()
    {
        if (Players.Any(p => p.Hand.Any()))
            return null;
        else
        {
            GameOver = true;

            var winningBookCount = Players.OrderByDescending(p => p.Books.Count()).First().Books.Count();
            var winners = Players.Where(p => p.Books.Count() == winningBookCount).ToList();

            string msg = "";
            if (winners.Count > 1)
            {
                msg = "The winners are " + string.Join(", ", winners) + "!";
                msg += Environment.NewLine;
                msg += $"Each of them is having {winningBookCount} books";
            }
            else
            {
                msg = $"The winner is {winners[0].Name}! {winners[0].Name} has {winningBookCount} books";
            }
            return msg;
        }
    }
}
