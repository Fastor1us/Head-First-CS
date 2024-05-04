using System.Windows;

namespace SwordDamageUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SwordDamage swordDamage = new SwordDamage(3, 2, 1.75f);

            int damage = swordDamage.CalculateDamage((bool)magicCheckBox.IsChecked, (bool)flamingCheckBox.IsChecked);

            damageTextBlock.Text = "Rolled " + swordDamage.Roll + " for " + damage.ToString() + "HP";
        }
    }
}
