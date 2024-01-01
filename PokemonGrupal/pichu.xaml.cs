using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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


namespace PokemonGrupal
{
    public sealed partial class MyUserControl1 : UserControl
    {
        private DispatcherTimer dtTime;
        private bool dead;
        private bool herido;
        private Storyboard sb2;
        private Storyboard sb3;
        private bool sleep;
        private bool potionDead;
        private int countHerido;
        private int countDead;

        public event EventHandler<string> ataquePokemon;

        public MyUserControl1()
        {
            InitializeComponent();
            this.pbHealth.Value = 100;
            this.pbEndurance.Value = 100;
            dead = false;
            herido = false;
            sleep = false;
            potionDead = false;
            sb2 = (Storyboard)this.Resources["Herido"];
            sb3 = (Storyboard)this.Resources["SinVida"];
            countHerido = 0;
            countDead = 0;
        }
        public void dañoPichu(float fallo, float mult)
        {
            float prob = fallo * 100;
            Random random = new Random();
            int RandomNumber = random.Next(0, 100);
            if (RandomNumber > prob)
            {
                this.pbHealth.Value = this.pbHealth.Value - (30 * mult);
                Storyboard sb = (Storyboard)this.Resources["daño"];
                sb.Completed += (s, e) => buttonEvent(s, e);
                sb.Begin();
            }
            else {
                this.Fallo.Visibility = Visibility.Visible;
            }
        }
        public double returnVida()
        {
            return this.pbHealth.Value;
        }
        public double returnEnergia()
        {
            return this.pbEndurance.Value;
        }
        public void descansar()
        {
            this.Fallo.Visibility = Visibility.Collapsed;
            this.pbEndurance.Value = 100;
        }
        private void useRedPotion(object sender, RoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseHealth;
            dtTime.Start();
            this.redPotion.Opacity = 0.5;
            this.redPotion.IsTapEnabled = false;
        }
        private void increaseHealth(object sender, object ev)
        {
            this.pbHealth.Value += 10;
            if (pbHealth.Value >= 100)
            {
                this.dtTime.Stop();
                this.redPotion.Opacity = 1;
                this.redPotion.IsTapEnabled = true;
                if (dead)
                {
                    countDead++;
                    Duration dur = new Duration(TimeSpan.FromSeconds(1));
                    sb3.Completed += (s, e) => endPotion(s, e);

                    sb3.AutoReverse = true;
                    sb3.Begin();
                    sb3.Seek(dur.TimeSpan);
                    dead = false;
                }
                else
                {
                    if (herido && !sleep)
                    {
                        countHerido++;
                        Duration dur = new Duration(TimeSpan.FromSeconds(0.5));
                        sb2.Completed += (s, e) => buttonEvent(s, e);
                        sb2.AutoReverse = true;
                        sb2.Begin();
                        sb2.Seek(dur.TimeSpan);
                        herido = false;
                    }
                }
            }
        }

        private void useYellowPotion(object sender, RoutedEventArgs e)
        {
            dtTime = new DispatcherTimer();
            dtTime.Interval = TimeSpan.FromMilliseconds(100);
            dtTime.Tick += increaseEndurance;
            dtTime.Start();
            this.yellowPotion.Opacity = 0.5;
        }
        private void increaseEndurance(object sender, object ev)
        {
            this.pbEndurance.Value += 10;
            if (pbEndurance.Value >= 100)
            {
                this.dtTime.Stop();
                this.yellowPotion.Opacity = 1;
                sleep = false;
                if (herido && !dead)
                {
                    countHerido++;
                    Duration dur = new Duration(TimeSpan.FromSeconds(0.5));
                    sb2.Completed += (s, e) => buttonEvent(s, e);
                    sb2.AutoReverse = true;
                    sb2.Begin();
                    sb2.Seek(dur.TimeSpan);
                    herido = false;
                }
            }
        }
        public void thunderAttack(object sender, object ev)
        {
            this.Fallo.Visibility = Visibility.Collapsed;
            sb2.Stop();
            Storyboard sb = (Storyboard)this.Resources["ataque"];
            sb.Completed += (s, e) => buttonEvent(s, e);
            sb.Begin();
            disableButton();
            this.pbEndurance.Value -= 30;
            ataquePokemon?.Invoke(this, "Ataque");
        }

        private void Daño(object sender, RoutedEventArgs ev)
        {
        }
        public void encanto(object sender, RoutedEventArgs ev)
        {
            this.Fallo.Visibility = Visibility.Collapsed;
            sb2.Stop();
            Storyboard sb = (Storyboard)this.Resources["Encanto"];
            sb.Completed += (s, e) => buttonEvent(s, e);
            sb.Begin();
            disableButton();
            this.pbEndurance.Value -= 30;
        }
        public void escudo(object sender, RoutedEventArgs ev)
        {
            this.Fallo.Visibility = Visibility.Collapsed;
            sb2.Stop();
            Storyboard sb = (Storyboard)this.Resources["Defensa"];
            sb.Completed += (s, e) => buttonEvent(s, e);
            sb.Begin();
            disableButton();
            this.pbEndurance.Value -= 30;
        }
        private void disableButton()
        {
            this.btDaño.IsEnabled = false;
            this.btDefensa.IsEnabled = false;
            this.btAtaque.IsEnabled = false;
            this.btAtaque2.IsEnabled = false;
        }
        private void enableButton()
        {
            this.btDaño.IsEnabled = true;
            this.btDefensa.IsEnabled = true;
            this.btAtaque.IsEnabled = true;
            this.btAtaque2.IsEnabled = true;
        }
        private void buttonEvent(object sender, object ev)
        {
            if (this.pbHealth.Value < 40 && this.pbHealth.Value > 0)
            {
                sb2.AutoReverse = false;
                herido = true;
                sb2.Completed += (s, e) => buttonEvent2(s, e);
                sb2.Begin();
            }
            else if (this.pbHealth.Value <= 0)
            {
                dead = true;
                herido = false;
                sb3.Completed += (s, e) => deadEvent(s, e);
                sb3.Begin();
            }
            else
            {
                isSleep();
            }

        }

        private void isSleep()
        {
            if (this.pbEndurance.Value <= 0)
            {
                if (!herido)
                {
                    sb2.AutoReverse = false;
                    herido = true;
                    sb2.Completed += (s, e) => buttonEvent2(s, e);
                    sb2.Begin();
                }
                this.btDaño.IsEnabled = true;
                this.btAtaque.IsEnabled = false;
                this.btAtaque2.IsEnabled = false;
                this.btDefensa.IsEnabled = false;
                sleep = true;
            }
            else
            {
                enableButton();
            }
        }
        private void buttonEvent2(object sender, object e)
        {
            if (countHerido > 0)
            {
                sb2.Stop();
            }
            if (!dead)
            {
                isSleep();
            }
        }
        private void endPotion(object sender, object e)
        {
            sb3.AutoReverse = false;
            sb3.Stop();
            isSleep();
        }
        private void deadEvent(object sender, object e)
        {
            if (countDead > 0)
            {
                sb3.Stop();
                Duration dur = new Duration(TimeSpan.FromSeconds(1));
                sb3.Begin();
                sb3.Seek(dur.TimeSpan);
                disableButton();
            }
        }
    }
}
