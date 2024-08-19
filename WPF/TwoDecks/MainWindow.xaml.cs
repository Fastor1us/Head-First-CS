using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TwoDecks;

/// <summary>
/// Логика взаимодействия для MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly Deck deck1;
    private readonly Deck deck2;
    public MainWindow()
    {
        deck1 = new Deck(true);
        Resources.Add("deck1", deck1);
        deck2 = new Deck(false);
        Resources.Add("deck2", deck2);
    }

    private void ListBox_Deck1_MouseDoubleClick(object sender, MouseButtonEventArgs e) =>
        CardTransferBetweenDecks(deck1, deck2, sender);

    private void ListBox_Deck2_MouseDoubleClick(object sender, MouseButtonEventArgs e) =>
        CardTransferBetweenDecks(deck2, deck1, sender);

    private static void CardTransferBetweenDecks(Deck fromDeck, Deck toDeck, object sender)
    {
        if (sender is ListBox listBox && listBox.SelectedItem != null)
        {
            Card selectedCard = (Card)listBox.SelectedItem;
            int selectedCardIndex = listBox.SelectedIndex;
            fromDeck.Remove(selectedCardIndex);
            toDeck.Add(selectedCard);
        }
    }

    private void Button_Shuffle_Click(object sender, RoutedEventArgs e) =>
        deck1.ShuffleDeck();

    private void Button_Reset_Click(object sender, RoutedEventArgs e) =>
        deck1.Reset();

    private void Button_Clear_Click(object sender, RoutedEventArgs e) =>
        deck2.Clear();

    private void Button_Sort_Click(object sender, RoutedEventArgs e) =>
        deck2.SortBySuitAndValue();
}
