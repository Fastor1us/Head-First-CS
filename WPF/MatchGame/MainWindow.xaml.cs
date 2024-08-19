using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MatchGame;

using System.Windows.Threading;
/// <summary>
/// Логика взаимодействия для MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    readonly DispatcherTimer timer = new();
    int tenthsOfSecondsElapsed;
    int matchesFound;

    public MainWindow()
    {
        InitializeComponent();

        timer.Interval = TimeSpan.FromSeconds(.1);
        timer.Tick += Timer_Tick;

        SetUpGame();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        tenthsOfSecondsElapsed++;
        timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
        if (matchesFound == 8)
        {
            timer.Stop();
            timeTextBlock.Text += " - Play again?";
        }
    }

    private void SetUpGame()
    {
        List<string> animalEmoji =
        [
            "🐷", "🐷",
            "🦁", "🦁",
            "🐤", "🐤",
            "🦄", "🦄",
            "🐙", "🐙",
            "🐳", "🐳",
            "🐻", "🐻",
            "🐹", "🐹"
        ];

        Random random = new();

        foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
        {
            if (textBlock.Name != "timeTextBlock")
            {
                textBlock.Visibility = Visibility.Visible;
                int index = random.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                textBlock.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }
        }

        timer.Start();
        tenthsOfSecondsElapsed = 0;
        matchesFound = 0;
    }

    TextBlock lastTextBlockClicked = new();
    bool findingMatch = false;

    private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
    {
        TextBlock textBlock = (TextBlock)sender;
        if (findingMatch == false)
        {
            textBlock.Visibility = Visibility.Hidden;
            lastTextBlockClicked = textBlock;
            findingMatch = true;
        }
        else if (textBlock?.Text == lastTextBlockClicked.Text)
        {
            textBlock.Visibility = Visibility.Hidden;
            findingMatch = false;
            matchesFound++;
        }
        else
        {
            lastTextBlockClicked.Visibility = Visibility.Visible;
            findingMatch = false;
        }
    }

    private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (matchesFound == 8) SetUpGame();
    }
}
