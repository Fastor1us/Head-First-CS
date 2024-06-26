﻿using System;
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

namespace ExperimentWithControls
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

        private void numberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            numberTextBlock.Text = numberTextBox.Text;
        }

        private void numberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        private void smallSlide_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            numberTextBlock.Text = smallSlide.Value.ToString("0");
        }

        private void bigSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            numberTextBlock.Text = bigSlider.Value.ToString("000-000-0000");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                numberTextBlock.Text = radioButton.Content.ToString();
            }
        }

        private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (myListBox.SelectedItem is ListBoxItem listBoxItem)
            {
                numberTextBlock.Text = listBoxItem.Content.ToString();
            }
        }

        private void readOnlyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (readOnlyComboBox.SelectedItem is ListBoxItem listBoxItem)
                numberTextBlock.Text = listBoxItem.Content.ToString();
        }

        private void editableComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
                numberTextBlock.Text = comboBox.Text;
        }
    }
}
