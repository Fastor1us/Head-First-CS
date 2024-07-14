using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static System.Net.Mime.MediaTypeNames;

namespace WeaponDamageUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Weapons { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Weapons = new ObservableCollection<string>
        {
            "Sword",
            "Axe",
            "Arrow",
        };
            weaponsListBox.ItemsSource = Weapons;
            weaponsListBox.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //damageTextBlock.Text = (string)weaponsListBox.SelectedItem;

            string weaponType = weaponsListBox.SelectedItem.ToString();
            object instance;
            switch (weaponType)
            {
                case "Sword":
                    instance = new SwordDamage();
                    break;
                case "Axe":
                    instance = new AxeDamage();
                    break;
                case "Arrow":
                    instance = new ArrowDamage();
                    break;
                default:
                    instance = new SwordDamage();
                    break;
            }
            bool isMagic = (bool)magicCheckBox.IsChecked;
            bool isFlaming = (bool)flamingCheckBox.IsChecked;
            var damage = ((dynamic)instance).CalculateDamage(isMagic, isFlaming);
            damageTextBlock.Text = $"damage: {damage}";
        }
    }
}
