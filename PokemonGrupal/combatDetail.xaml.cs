using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Chat;
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
    public sealed partial class combatDetail : Page
    {
        public MyUserControl1 pichuP1 = null;
        public wartortle wartortleP2 = null;
        public MyUserControl1 pichuP2 = null;
        public wartortle wartortleP1 = null;
        public piplup piplupP1 = null;
        public piplup piplupP2 = null;
        public bool turnPlayer1 = true;
        public float multiplierAttack1 = 1.00f;
        public float multiplierAttack2 = 1.00f;
        public bool encantoP1 = false;
        public bool encantoP2 = false;
        public float fallo = 0.2f;
        public combatDetail()
        {
            this.InitializeComponent();
            inicio();
        }

        public void inicio() {
            pichuP1 = this.player1Pichu;
            wartortleP2 = this.player2Wartortle;
            pichuP2 = this.player2Pichu;
            wartortleP1 = this.player1Wartortle;
            piplupP1 = this.player1Piplup;
            piplupP2 = this.player2Piplup;

            switch (CombatePage.GlobalVariables.palyer1) {
                case "Pichu":
                    {
                        this.pichuP1.Visibility = Visibility.Visible;
                        break;
                    }
                case "Wartortle":
                    {
                        this.wartortleP1.Visibility = Visibility.Visible;
                        break;
                    }
                case "Piplup":
                    {
                        this.piplupP1.Visibility = Visibility.Visible;
                        break;
                    }
            }
            switch (CombatePage.GlobalVariables.palyer2)
            {
                case "Pichu":
                    {
                        this.pichuP2.Visibility = Visibility.Visible;
                        break;
                    }
                case "Wartortle":
                    {
                        this.wartortleP2.Visibility = Visibility.Visible;
                        break;
                    }
                case "Piplup":
                    {
                        this.piplupP2.Visibility = Visibility.Visible;
                        break;
                    }
            }
            cambioTurno();
        }

        private void ataque(object sender, RoutedEventArgs e)
        {
            if (this.turnPlayer1) {
                switch (CombatePage.GlobalVariables.palyer1) {
                    case "Pichu": {
                            this.pichuP1.thunderAttack(sender, e);
                            break;
                        }
                    case "Wartortle":
                        {
                            this.wartortleP1.btAtaque1_click(sender, e);
                            this.AttackP1_Ataque2.Content = "Ataque 2";
                            break;
                        }
                    case "Piplup":
                        {
                            this.piplupP1.rayoBurbuja(sender, e);
                            this.AttackP1_Ataque2.Content = "Gruñido";
                            break;
                        }
                }
                switch (CombatePage.GlobalVariables.palyer2)
                {
                    case "Pichu":
                        {
                            this.pichuP2.dañoPichu(fallo, multiplierAttack1);
                            break;
                        }
                    case "Wartortle":
                        {
                            this.wartortleP2.daño(fallo, multiplierAttack1);
                            this.AttackP2_Ataque2.Content = "Ataque 2";
                            break;
                        }
                    case "Piplup":
                        {
                            this.piplupP2.daño(fallo, multiplierAttack1);
                            this.AttackP2_Ataque2.Content = "Gruñido";
                            break;
                        }
                }
                this.turnPlayer1 = false;
                terminarEncanto();
                terminarEscudo();
                cambioTurno();
            } else {
                switch (CombatePage.GlobalVariables.palyer2)
                {
                    case "Pichu":
                        {
                            this.pichuP2.thunderAttack(sender, e);
                            break;
                        }
                    case "Wartortle":
                        {
                            this.wartortleP2.btAtaque1_click(sender, e);
                            break;
                        }
                    case "Piplup":
                        {
                            this.piplupP2.rayoBurbuja(sender, e);
                            break;
                        }
                }
                switch (CombatePage.GlobalVariables.palyer1)
                {
                    case "Pichu":
                        {
                            this.pichuP1.dañoPichu(fallo, multiplierAttack2);
                            break;
                        }
                    case "Wartortle":
                        {
                            this.wartortleP1.daño(fallo, multiplierAttack2);
                            break;
                        }
                    case "Piplup":
                        {
                            this.piplupP1.daño(fallo, multiplierAttack1);
                            break;
                        }
                }
                this.turnPlayer1 = true;
                terminarEncanto();
                terminarEscudo();
                cambioTurno();
            }
        }

        private void ataque2(object sender, RoutedEventArgs e) {
            if (this.turnPlayer1)
            {
                switch (CombatePage.GlobalVariables.palyer1)
                {
                    case "Wartortle":
                        {
                            this.wartortleP1.btAtaque2_click(sender, e);
                            Task.Delay(4000);
                            break;
                        }
                    case "Piplup":
                        {
                            this.piplupP1.gruñido(sender, e);
                            break;
                        }
                }
                switch (CombatePage.GlobalVariables.palyer2)
                {
                    case "Pichu":
                        {
                            this.pichuP2.dañoPichu(fallo, multiplierAttack1);
                            break;
                        }
                    case "Wartortle":
                        {
                            this.wartortleP2.daño(fallo, multiplierAttack1);
                            break;
                        }
                    case "Piplup":
                        {
                            this.piplupP2.daño(fallo, multiplierAttack1);
                            break;
                        }
                }
                this.turnPlayer1 = false;
                terminarEncanto();
                terminarEscudo();
                cambioTurno();
            }
            else
            {
                switch (CombatePage.GlobalVariables.palyer2)
                {
                    case "Wartortle":
                        {
                            this.wartortleP2.btAtaque2_click(sender, e);
                            Task.Delay(4000);
                            break;
                        }
                    case "Piplup":
                        {
                            this.piplupP2.gruñido(sender, e);
                            break;
                        }
                }
                switch (CombatePage.GlobalVariables.palyer1)
                {
                    case "Pichu":
                        {
                            this.pichuP1.dañoPichu(fallo, multiplierAttack2);
                            break;
                        }
                    case "Wartortle":
                        {
                            this.wartortleP1.daño(fallo, multiplierAttack2);
                            break;
                        }
                    case "Piplup":
                        {
                            this.piplupP1.daño(fallo, multiplierAttack1);
                            break;
                        }
                }
                this.turnPlayer1 = true;
                terminarEncanto();
                terminarEscudo();
                cambioTurno();
            }
        }
        private void encanto(object sender, RoutedEventArgs e) {
            if (this.turnPlayer1)
            {
                switch (CombatePage.GlobalVariables.palyer1)
                {
                    case "Pichu":
                        {
                            this.pichuP1.encanto(sender, e);
                            Task.Delay(3000);
                            break;
                        }
                }
                this.turnPlayer1 = false;
                terminarEncanto();
                this.encantoP2 = true;
                terminarEscudo();
                cambioTurno();
            }
            else
            {
                switch (CombatePage.GlobalVariables.palyer2)
                {
                    case "Pichu":
                        {
                            this.pichuP2.encanto(sender, e);
                            Task.Delay(3000);
                            break;
                        }
                }
                this.turnPlayer1 = true;
                terminarEncanto();
                this.encantoP1 = true;
                terminarEscudo();
                cambioTurno();
            }
        }
        private void escudo(object sender, RoutedEventArgs e) {
            if (this.turnPlayer1)
            {
                switch (CombatePage.GlobalVariables.palyer1)
                {
                    case "Pichu":
                        {
                            this.pichuP1.escudo(sender, e);
                            Task.Delay(2000);
                            break;
                        }
                    case "Wartortle":
                        {
                            this.wartortleP1.btCubrirse_click(sender, e);
                            Task.Delay(2000);
                            break;
                        }
                    case "Piplup":
                        {
                            this.piplupP1.proteccion(sender, e);
                            break;
                        }
                }
                this.turnPlayer1 = false;
                terminarEscudo();
                this.multiplierAttack2 = 0.5f;
                terminarEncanto();
                cambioTurno();
            }
            else
            {
                switch (CombatePage.GlobalVariables.palyer2)
                {
                    case "Pichu":
                        {
                            this.pichuP2.escudo(sender, e);
                            Task.Delay(2000);
                            break;
                        }
                    case "Wartortle":
                        {
                            this.wartortleP2.btCubrirse_click(sender, e);
                            Task.Delay(2000);
                            break;
                        }
                    case "Piplup":
                        {
                            this.piplupP2.proteccion(sender, e);
                            break;
                        }
                }
                this.turnPlayer1 = true;
                terminarEscudo();
                this.multiplierAttack1 = 0.5f;
                terminarEncanto();
                cambioTurno();
            }
        }
        private void descansar(object sender, RoutedEventArgs e) {
            if (this.turnPlayer1)
            {
                switch (CombatePage.GlobalVariables.palyer1)
                {
                    case "Pichu":
                        {
                            this.pichuP1.descansar();
                            break;
                        }
                    case "Wartortle":
                        {
                            this.wartortleP1.btDormir_click(sender, e);
                            Task.Delay(4000);
                            break;
                        }
                    case "Piplup":
                        {
                            this.piplupP1.descansar(sender, e);
                            break;
                        }
                }
                this.turnPlayer1 = false;
                terminarEncanto();
                terminarEscudo();
                cambioTurno();
            }
            else
            {
                switch (CombatePage.GlobalVariables.palyer2)
                {
                    case "Pichu":
                        {
                            this.pichuP2.descansar();
                            break;
                        }
                    case "Wartortle":
                        {
                            this.wartortleP2.btDormir_click(sender, e);
                            Task.Delay(4000);
                            break;
                        }
                    case "Piplup":
                        {
                            this.piplupP2.descansar(sender, e);
                            break;
                        }
                }
                this.turnPlayer1 = true;
                terminarEncanto();
                terminarEscudo();
                cambioTurno();
            }
        }

        private void cambioTurno() {
            if (this.pichuP1.returnVida() <= 0)
            {
                this.grid_fin.Visibility = Visibility.Visible;
                this.Player1Win.Visibility = Visibility.Collapsed;
                this.Player2Win.Visibility = Visibility.Visible;
                disableButtons();
            }
            else if (this.pichuP2.returnVida() <= 0)
            {
                this.grid_fin.Visibility = Visibility.Visible;
                this.Player1Win.Visibility = Visibility.Visible;
                this.Player2Win.Visibility = Visibility.Collapsed;
                disableButtons();
            }
            else if (this.wartortleP1.returnVida() <= 0)
            {
                this.grid_fin.Visibility = Visibility.Visible;
                this.Player1Win.Visibility = Visibility.Collapsed;
                this.Player2Win.Visibility = Visibility.Visible;
                disableButtons();
            }
            else if (this.wartortleP2.returnVida() <= 0)
            {
                this.grid_fin.Visibility = Visibility.Visible;
                this.Player1Win.Visibility = Visibility.Visible;
                this.Player2Win.Visibility = Visibility.Collapsed;
                disableButtons();
            }
            else if (this.piplupP1.returnVida() <= 0)
            {
                this.grid_fin.Visibility = Visibility.Visible;
                this.Player1Win.Visibility = Visibility.Collapsed;
                this.Player2Win.Visibility = Visibility.Visible;
                disableButtons();
            }
            else if (this.piplupP2.returnVida() <= 0)
            {
                this.grid_fin.Visibility = Visibility.Visible;
                this.Player1Win.Visibility = Visibility.Visible;
                this.Player2Win.Visibility = Visibility.Collapsed;
                disableButtons();
            }
            else
            {
                if (this.turnPlayer1)
                {
                    if (multiplierAttack1 < 1.00f)
                    {
                        this.btn_MutiplierP1.Content = "ATQ : X0.50";
                    }
                    else
                    {
                        this.btn_MutiplierP1.Content = "ATQ : X1.00";
                    }
                    if (encantoP1)
                    {
                        this.btn_encantoP1.Visibility = Visibility.Visible;
                        fallo = 0.5f;
                    }
                    else
                    {
                        this.btn_encantoP1.Visibility = Visibility.Collapsed;
                        fallo = 0.2f;
                    }
                    disableButtons();
                    switch (CombatePage.GlobalVariables.palyer1)
                    {
                        case "Pichu":
                            {
                                turnoPichuP1();
                                break;
                            }
                        case "Wartortle":
                            {
                                turnoWartortleP1();
                                break;
                            }
                        case "Piplup":
                            {
                                turnoPiplupP1();
                                break;
                            }
                    }
                }
                else
                {
                    if (multiplierAttack2 < 1.00f)
                    {
                        this.btn_MutiplierP2.Content = "ATQ : X0.50";
                    }
                    else
                    {
                        this.btn_MutiplierP2.Content = "ATQ : X1.00";
                    }
                    if (encantoP2)
                    {
                        this.btn_encantoP2.Visibility = Visibility.Visible;
                        fallo = 0.5f;
                    }
                    else
                    {
                        this.btn_encantoP2.Visibility = Visibility.Collapsed;
                        fallo = 0.2f;
                    }
                    disableButtons();
                    if (!CombatePage.GlobalVariables.IA)
                    {
                        switch (CombatePage.GlobalVariables.palyer2)
                        {
                            case "Pichu":
                                {
                                    turnoPichuP2();
                                    break;
                                }
                            case "Wartortle":
                                {
                                    turnoWartortleP2();
                                    break;
                                }
                            case "Piplup":
                                {
                                    turnoPiplupP2();
                                    break;
                                }
                        }
                    }
                    else {
                        turnIA();
                    }
                }
            }
        }
        private void turnoPichuP1() {
            if (this.pichuP1.returnEnergia() <= 0)
            {
                this.AttackP1_Descansar.Visibility = Visibility.Visible;
            }
            else
            {
                this.AttackP1.Visibility = Visibility.Visible;
                this.AttackP1_Encanto.Visibility = Visibility.Visible;
                this.AttackP1_Escudo.Visibility = Visibility.Visible;
                this.AttackP1_Descansar.Visibility = Visibility.Visible;
            }
        }
        private void turnoWartortleP1()
        {
            if(this.wartortleP1.returnEnergia() <= 0){
                this.AttackP1_Descansar.Visibility = Visibility.Visible;
            } else {
                this.AttackP1.Visibility = Visibility.Visible;
                this.AttackP1_Ataque2.Visibility = Visibility.Visible;
                this.AttackP1_Escudo.Visibility = Visibility.Visible;
                this.AttackP1_Descansar.Visibility = Visibility.Visible;
            }
        }
        private void turnoPiplupP1()
        {
            if (this.piplupP1.returnEnergia() <= 0)
            {
                this.AttackP1_Descansar.Visibility = Visibility.Visible;
            }
            else
            {
                this.AttackP1.Visibility = Visibility.Visible;
                this.AttackP1_Ataque2.Visibility = Visibility.Visible;
                this.AttackP1_Escudo.Visibility = Visibility.Visible;
                this.AttackP1_Descansar.Visibility = Visibility.Visible;
            }
        }
        private void turnoPichuP2()
        {
            if (this.pichuP2.returnEnergia() <= 0)
            {
                this.AttackP2_Descansar.Visibility = Visibility.Visible;
            }
            else {
                this.AttackP2.Visibility = Visibility.Visible;
                this.AttackP2_Encanto.Visibility = Visibility.Visible;
                this.AttackP2_Escudo.Visibility = Visibility.Visible;
                this.AttackP2_Descansar.Visibility = Visibility.Visible;
            }
        }
        private void turnoWartortleP2()
        {
            if (this.wartortleP2.returnEnergia() <= 0)
            {
                this.AttackP2_Descansar.Visibility = Visibility.Visible;
            }
            else
            {
                this.AttackP2.Visibility = Visibility.Visible;
                this.AttackP2_Ataque2.Visibility = Visibility.Visible;
                this.AttackP2_Escudo.Visibility = Visibility.Visible;
                this.AttackP2_Descansar.Visibility = Visibility.Visible;
            }
        }
        private void turnoPiplupP2()
        {
            if (this.piplupP2.returnEnergia() <= 0)
            {
                this.AttackP2_Descansar.Visibility = Visibility.Visible;
            }
            else
            {
                this.AttackP2.Visibility = Visibility.Visible;
                this.AttackP2_Ataque2.Visibility = Visibility.Visible;
                this.AttackP2_Escudo.Visibility = Visibility.Visible;
                this.AttackP2_Descansar.Visibility = Visibility.Visible;
            }
        }
        private void disableButtons()
        {
            this.AttackP1.Visibility = Visibility.Collapsed;
            this.AttackP1_Ataque2.Visibility = Visibility.Collapsed;
            this.AttackP1_Escudo.Visibility = Visibility.Collapsed;
            this.AttackP1_Descansar.Visibility = Visibility.Collapsed;
            this.AttackP1_Encanto.Visibility = Visibility.Collapsed;
            this.AttackP2.Visibility = Visibility.Collapsed;
            this.AttackP2_Ataque2.Visibility = Visibility.Collapsed;
            this.AttackP2_Escudo.Visibility = Visibility.Collapsed;
            this.AttackP2_Descansar.Visibility = Visibility.Collapsed;
            this.AttackP2_Encanto.Visibility = Visibility.Collapsed;
        }
        private void terminarEncanto() {
            if (encantoP1 || encantoP2) {
                this.encantoP1 = false;
                this.encantoP2 = false;
            }
        }
        private void terminarEscudo() {
            if (this.multiplierAttack1 < 1.00f || this.multiplierAttack2 < 1.00f) {
                this.multiplierAttack1 = 1.00f;
                this.multiplierAttack2 = 1.00f;
            }
        }

        private void btn_inicio_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(InicioPage));
        }

        private void btn_combate_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CombatePage));
        }
        private void turnIA() {
            object sender = null;
            RoutedEventArgs e = null;
            Random random = new Random();
            int RandomNumber = random.Next(0, 3);
            if (this.pichuP2.returnEnergia() <= 0 || this.wartortleP2.returnEnergia() <= 0 || this.piplupP2.returnEnergia() <= 0)
            {
                descansar(sender, e);
            }
            else
            {
                switch (RandomNumber)
                {
                    case 0:
                        {
                            ataque(sender, e);
                            break;
                        }
                    case 1:
                        {
                            switch (CombatePage.GlobalVariables.palyer2)
                            {
                                case "Pichu":
                                    {
                                        encanto(sender, e);
                                        break;
                                    }
                                case "Wartortle":
                                    {
                                        ataque2(sender, e);
                                        break;
                                    }
                                case "Piplup":
                                    {
                                        ataque2(sender, e);
                                        break;
                                    }
                            }
                            break;
                        }
                    case 2:
                        {
                            escudo(sender, e);
                            break;
                        }
                    case 3:
                        {
                            descansar(sender, e);
                            break;
                        }
                }
            }
        }
    }
}
