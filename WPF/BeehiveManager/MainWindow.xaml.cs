using System.Windows;

namespace BeehiveManager;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly Queen queen;

    public MainWindow()
    {
        InitializeComponent();
        queen = (Queen)Resources["queen"];
    }

    private void AssignJob_Click(object sender, RoutedEventArgs e)
    {
        queen.AssignBee(jobSelector.Text);
        assignJobButton.IsEnabled = queen.UnassignedWorkers > 1;
    }

    private void WorkShift_Click(object sender, RoutedEventArgs e)
    {
        queen.WorkTheNextShift();
        assignJobButton.IsEnabled = queen.UnassignedWorkers > 1;
        workTheNextShiftButton.IsEnabled =
            queen.CostPerShift < HoneyVault.Honey;
    }
}