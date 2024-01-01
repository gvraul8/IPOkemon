using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Playback;
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
    public sealed partial class piplup : UserControl
    {
        private string ruta = Directory.GetCurrentDirectory();
        private MediaPlayer mediaAnimaciones = new MediaPlayer();
        private DispatcherTimer t1;
        private DispatcherTimer t2;
        private DispatcherTimer t3;
        private int incremento = 100;
        private int decremento = 30;

        public piplup()
        {
            InitializeComponent();
        }

        private void morir()
        {
            Storyboard morir = (Storyboard)this.Resources["animacionMuerte"];
            morir.Completed += finMuerte;

            morir.Begin();
        }
        public void daño(float fallo, float mult)
        {
            float prob = fallo * 100;
            Random random = new Random();
            int RandomNumber = random.Next(0, 100);
            if (RandomNumber > prob)
            {
                this.barraSalud.Value = this.barraSalud.Value - (30 * mult);
                if (this.barraSalud.Value <= 0)
                {
                    morir();
                }
            }
            else
            {
                this.Fallo.Visibility = Visibility.Visible;
            }
        }
        public double returnVida()
        {
            return this.barraSalud.Value;
        }
        public double returnEnergia()
        {
            return this.barraEnergia.Value;
        }

        private void finMuerte(object sender, object ev)
        {

        }

        public void descansar(object sender, RoutedEventArgs e)
        {
            this.Fallo.Visibility = Visibility.Collapsed;
            btnDescansar.IsEnabled = false;
            Storyboard descansar = (Storyboard)this.Resources["animacionDescansar"];
            descansar.Completed += finDescansar;
            descansar.Begin();

            barraEnergia.Value += incremento;
        }

        private void finDescansar(object sender, object ev)
        {
            btnDescansar.IsEnabled = true;
            mediaAnimaciones.Pause();
        }

        private void eventoComer(object sender, object ev)
        {
            Storyboard comer = (Storyboard)this.Resources["animacionComer"];
            comer.Completed += finComer;
            comer.Begin();

            barraEnergia.Value += incremento;
            mediaAnimaciones.Play();
        }

        private void finComer(object sender, object ev)
        {
            btnComer.IsEnabled = true;
            mediaAnimaciones.Pause();
        }

        private void jugar(object sender, RoutedEventArgs e)
        {
            btnJugar.IsEnabled = false;
            Storyboard jugar = (Storyboard)this.Resources["animacionJugar"];
            jugar.Completed += finJugar;
            jugar.Begin();

            barraDiversion.Value += incremento;
            mediaAnimaciones.Play();
        }

        private void finJugar(object sender, object ev)
        {
            btnJugar.IsEnabled = true;
        }

        public void proteccion(object sender, RoutedEventArgs e)
        {
            this.Fallo.Visibility = Visibility.Collapsed;
            btnAtaqueProteccion.IsEnabled = false;
            Storyboard proteccion = (Storyboard)this.Resources["animacionProteccion"];
            proteccion.Completed += finProteccion;
            proteccion.Begin();

            barraEnergia.Value -= decremento;
            mediaAnimaciones.Play();
        }

        private void finProteccion(object sender, object ev)
        {
            btnAtaqueProteccion.IsEnabled = true;
        }

        public void rayoBurbuja(object sender, RoutedEventArgs e)
        {
            this.Fallo.Visibility = Visibility.Collapsed;
            btnAtaqueRayoBurbuja.IsEnabled = false;
            Storyboard rayoBurbuja = (Storyboard)this.Resources["animacionRayoBurbuja"];
            rayoBurbuja.Completed += finRayoBurbuja;
            rayoBurbuja.Begin();

            barraEnergia.Value -= decremento;

            mediaAnimaciones.Play();
        }

        private void finRayoBurbuja(object sender, object ev)
        {
            btnAtaqueRayoBurbuja.IsEnabled = true;
        }

        public void gruñido(object sender, RoutedEventArgs e)
        {
            this.Fallo.Visibility = Visibility.Collapsed;
            btnAtaqueGruñido.IsEnabled = false;
            Storyboard gruñido = (Storyboard)this.Resources["animacionGruñido"];
            gruñido.Completed += finGruñido;
            gruñido.Begin();

            barraEnergia.Value -= decremento;

            mediaAnimaciones.Play();
        }

        private void finGruñido(object sender, object ev)
        {
            btnAtaqueGruñido.IsEnabled = true;
        }

        private void sorpresa(object sender, RoutedEventArgs e)
        {
            btnPiplup.IsEnabled = false;
            Storyboard sorpresa = (Storyboard)this.Resources["animacionSorpresa"];
            sorpresa.Completed += finSorpresa;
            sorpresa.Begin();

            mediaAnimaciones.Play();
        }

        private void finSorpresa(object sender, object ev)
        {
            btnPiplup.IsEnabled = true;
        }
    }
}
