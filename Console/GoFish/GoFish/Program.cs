using GoFish.Classes;
using GoFish.Enums;

namespace GoFish;

class Program
{
    static GameController gameController;

    static void Main(string[] args)
    {
        while (true)
        {
            if (gameController == null)
            {
                PlayNewGame();
            }
            else
            {
                Console.WriteLine("Press Q to quit, any other key for a new game.");
                if (Console.ReadKey(true).KeyChar.ToString().ToUpper() == "Q") return;
                Console.WriteLine(" [x] Starting new game..");
                PlayNewGame();
            }
        }
    }

    static void PlayNewGame()
    {
        string humanName;
        while (true)
        {
            Console.Write("Enter your name (1-20 characters): ");
            humanName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(humanName) && humanName.Length <= 20)
                break;
            else
                Console.WriteLine("Please enter a valid name between 1 and 20 characters.");
        }
        int opponentCount;
        while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out opponentCount)
        || opponentCount < 1 || opponentCount > 4)
        {
            Console.WriteLine("Please enter a number from 1 to 4");
        }
        Console.WriteLine($"{Environment.NewLine}Welcome to the game, {humanName}");
        gameController = new(humanName, Enumerable.Range(1, opponentCount).Select(i => $"Computer #{i}"));
        Console.WriteLine(gameController.Status);
        while (!gameController.GameOver)
        {
            while (!gameController.GameOver)
            {
                Console.WriteLine($"Your hand:");
                foreach (
                    var card in gameController.HumanPlayer.Hand
                        .OrderBy(card => card.Suit)
                        .OrderBy(card => card.Value)
                ) Console.WriteLine(card);
                if (gameController.HumanPlayer.Hand.Any())
                {
                    var value = PromptForAValue();
                    var player = PromptForAnOpponent();
                    gameController.NextRound(player, value);
                }
                else
                {
                    gameController.ComputerPlayersPlayNextRound();
                }
                Console.WriteLine(gameController.Status);
                var res = gameController.CheckForWinner();
                if (res != null) Console.WriteLine(res);
            }
        }
    }

    /// <summary>
    /// Prompt the human player for a card value that's in their hand
    /// </summary>
    /// <returns>The value that the player asked for</returns>
    static Values PromptForAValue()
    {
        var handValues = gameController.HumanPlayer.Hand.Select(card => card.Value).ToList();
        Console.Write("What card value do you want to ask for? ");
        while (true)
        {
            if (Enum.TryParse(typeof(Values), Console.ReadLine(), out var value) && handValues.Contains((Values)value))
                return (Values)value;
            else
                Console.WriteLine("Please enter a value in your hand.");
        }
    }

    /// <summary>
    /// Prompt the human player for an opponent to ask for a card
    /// </summary>
    /// <returns>The opponent to ask</returns>
    static Player PromptForAnOpponent()
    {
        var opponents = gameController.Opponents.Where(o => o.Hand.Any()).ToList();
        for (int i = 1; i <= opponents.Count; i++)
            Console.WriteLine($"{i}. {opponents[i - 1]}");
        Console.Write("Who do you want to ask for a card? ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int selection) && selection >= 1 && selection <= opponents.Count)
                return opponents[selection - 1];
            else
                Console.Write($"Please enter a number from 1 to {opponents.Count}: ");
        }
    }
}
