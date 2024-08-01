using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeehiveManagerUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Queen queen;

        public MainWindow()
        {
            InitializeComponent();
            queen = Resources["queen"] as Queen;
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
}
