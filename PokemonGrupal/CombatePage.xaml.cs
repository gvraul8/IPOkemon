using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace PokemonGrupal
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CombatePage : Page
    {
        public static class GlobalVariables
        {
            public static string palyer1 { get; set; } = "";
            public static string palyer2 { get; set; } = "";
            public static bool IA { get; set; } = false;
        }
        public CombatePage()
        {
            this.InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        private void grid1Tapped(object sender, RoutedEventArgs e)
        {
            backPlayer1();
            GlobalVariables.palyer1 = "Pichu";
            this.grid1.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
        }
        private void grid2Tapped(object sender, RoutedEventArgs e)
        {
            backPlayer1();
            GlobalVariables.palyer1 = "Piplup";
            this.grid2.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
        }
        private void grid3Tapped(object sender, RoutedEventArgs e)
        {
            backPlayer1();
            GlobalVariables.palyer1 = "Wartortle";
            this.grid3.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
        }
        private void grid4Tapped(object sender, RoutedEventArgs e)
        {
            backPlayer2();
            GlobalVariables.palyer2 = "Pichu";
            this.grid4.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
        }
        private void grid5Tapped(object sender, RoutedEventArgs e)
        {
            backPlayer2();
            GlobalVariables.palyer2 = "Piplup";
            this.grid5.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
        }
        private void grid6Tapped(object sender, RoutedEventArgs e)
        {
            backPlayer2();
            GlobalVariables.palyer2 = "Wartortle";
            this.grid6.Background = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
        }
        private void backPlayer1() {
            this.grid1.Background = new SolidColorBrush(Color.FromArgb(0, 14, 0, 0));
            this.grid2.Background = new SolidColorBrush(Color.FromArgb(0, 14, 0, 0));
            this.grid3.Background = new SolidColorBrush(Color.FromArgb(0, 14, 0, 0));
        }
        private void backPlayer2()
        {
            this.grid4.Background = new SolidColorBrush(Color.FromArgb(0, 14, 0, 0));
            this.grid5.Background = new SolidColorBrush(Color.FromArgb(0, 14, 0, 0));
            this.grid6.Background = new SolidColorBrush(Color.FromArgb(0, 14, 0, 0));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (GlobalVariables.palyer1 != "" && GlobalVariables.palyer2 != "") {
                if(this.artifi.IsChecked == true) {
                    GlobalVariables.IA = true;
                }
                Frame.Navigate(typeof(combatDetail));
            }
        }
    }
}
