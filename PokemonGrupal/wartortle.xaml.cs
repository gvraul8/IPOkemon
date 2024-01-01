using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace PokemonGrupal
{
    public sealed partial class wartortle : UserControl
    {

        DispatcherTimer dtTime;
        DispatcherTimer dtTime2;

        public wartortle()
        {
            this.InitializeComponent();
        }

        ///////////////////////////////////// VIDA ///////////////////////////////////////////////

        public void daño(float fallo, float mult) {
            float prob = fallo * 100;
            Random random = new Random();
            int RandomNumber = random.Next(0, 100);
            if (RandomNumber > prob)
            {
                this.pbVida.Value = this.pbVida.Value - (30 * mult);
            }
            else
            {
                this.Fallo.Visibility = Visibility.Visible;
            }
        }
        public double returnVida() {
            return this.pbVida.Value;
        }
        public double returnEnergia() {
            return this.pbEnergia.Value;
        }
        private void aumentarVida(object sender, PointerRoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(50);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
            this.imgPocionVida.Opacity = 0.5;
        }

        private void increaseHealth(object sender, object e)
        {
            this.pbVida.Value += 0.2;
            if (pbVida.Value >= 100)
            {
                this.dtTime.Stop();
                this.imgPocionVida.Opacity = 1;
            }
        }

        private void imgPocionVida_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Storyboard vida = (Storyboard)this.Resources["Vida"];
            vida.Begin();

            this.aumentarVida(sender, e);
        }


        ///////////////////////////////////// ENERGIA ///////////////////////////////////////////////

        private void aumentarEnergia(object sender, PointerRoutedEventArgs e)
        {
            dtTime2 = new DispatcherTimer();
            dtTime2.Interval = TimeSpan.FromMilliseconds(50);
            dtTime2.Tick += increaseEnergy;
            dtTime2.Start();
            this.imgPocionEnergia.Opacity = 0.5;
        }

        private void increaseEnergy(object sender, object e)
        {
            this.pbEnergia.Value += 0.3;
            if (pbEnergia.Value >= 100)
            {
                this.dtTime2.Stop();
                this.imgPocionEnergia.Opacity = 1;
            }
        }

        private void imgPocionEnergia_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Storyboard energia = (Storyboard)this.Resources["Energia"];
            energia.Begin();

            this.aumentarEnergia(sender, e);

            this.btAtaque1.IsEnabled = true;
            this.btAtaque2.IsEnabled = true;
        }

        ///////////////////////////////////// ATAQUES ///////////////////////////////////////////////

        public void btAtaque1_click(object sender, RoutedEventArgs e)
        {
            this.Fallo.Visibility = Visibility.Collapsed;
            Storyboard ataque1 = (Storyboard)this.Resources["Ataque1"];
            ataque1.Begin();

            this.pbEnergia.Value -= 30;

            if (pbEnergia.Value <= 0)
            {
                // PREGUNTAR COMO PONER TOOLTIP CUANDO ESTAN DESACTIVADOS LOS BOTONES
                this.btAtaque1.IsEnabled = false;
                this.btAtaque2.IsEnabled = false;
            }
        }

        public void btAtaque2_click(object sender, RoutedEventArgs e)
        {
            this.Fallo.Visibility = Visibility.Collapsed;
            Storyboard ataque2 = (Storyboard)this.Resources["Ataque2"];
            ataque2.Begin();

            this.pbEnergia.Value -= 30;

            if (pbEnergia.Value <= 0)
            {
                this.btAtaque1.IsEnabled = false;
                this.btAtaque2.IsEnabled = false;
            }

        }

        public void btCubrirse_click(object sender, RoutedEventArgs e)
        {
            this.pbEnergia.Value -= 30;
            this.Fallo.Visibility = Visibility.Collapsed;
            Storyboard cubrirse = (Storyboard)this.Resources["Cubrirse"];
            cubrirse.Begin();
        }


        ////////////////////////// DORMIR //////////////////////////////////////////

        private void descansar(object sender, RoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(25);
            dtTime.Tick += sleep;
            dtTime.Start();
        }

        private void sleep(object sender, object e)
        {
            this.pbEnergia.Value += 0.2;
            if (pbEnergia.Value >=100)
            {
                this.dtTime.Stop();
            }
        }

        public void btDormir_click(object sender, RoutedEventArgs e)
        {
            this.Fallo.Visibility = Visibility.Collapsed;
            Storyboard dormir = (Storyboard)this.Resources["Dormir"];
            dormir.Begin();

            this.pbEnergia.Value = 100;
        }


        ////////////////////////////////////         GETTERS SETTERS      ///////////////////////////////////////////////////

        public double vida
        {
            get { return this.pbVida.Value; }
            set { this.pbVida.Value = value; }
        }

    }
}
