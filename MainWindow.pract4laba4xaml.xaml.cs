using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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


namespace prct4Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DS3Entities context = new DS3Entities();

        public MainWindow()
        {
            InitializeComponent();

            PlayerDGR.ItemsSource = context.Players.ToList();
            WeaponClass.ItemsSource = context.Weapons.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlayerDGR.ItemsSource = context.Players.ToList().Where(item => item.PlayerName.Contains(SearchTxt.Text));
        }

        private void PlayerDGR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WeaponClass.SelectedItem != null)
            {
                var selected = WeaponClass.SelectedItem as Weapons;
                PlayerDGR.ItemsSource = context.Players.ToList().Where(item => item.Weapons == selected);
            }

        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PlayerDGR.ItemsSource = context.Players.ToList();
        }

    }
}
