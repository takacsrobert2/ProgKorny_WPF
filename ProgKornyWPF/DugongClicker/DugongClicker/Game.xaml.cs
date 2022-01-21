using System;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DugongClicker
{   
    public partial class Game : Window
    {
        // Global Variables
        double Boldogsag = 0;
        double UpgradeCost = 10;
        double FeedUpCost = 25;
        double PremiumUpCost = 100;
        double BPM = 1;

        public Game()
        {
            InitializeComponent();

            // DispatcherTimer példányosítás
            DispatcherTimer TickTimer = new System.Windows.Threading.DispatcherTimer();
            TickTimer.Tick += new EventHandler(TicTimer);

            // Az intervallum amiben meghívjuk a TickTimert
            TickTimer.Interval = new TimeSpan(0, 0, 1);
            TickTimer.Start();
        }

        void TicTimer(object sender, EventArgs e)
        {
            Boldogsag = Boldogsag + BPM; //BPM = Boldogsag/másodperc
            Boldogsag = Math.Floor(Boldogsag);
            BPM = Math.Floor(BPM);
            txt_Boldogsag.Text = Convert.ToString(Boldogsag);
        }

        // Gombnyomásra hozzáadja az aktuális összeget a BPM-hez
        private void bt_Clicker_Click(object sender, RoutedEventArgs e)
        {
            Boldogsag = Boldogsag + BPM;

            txt_Boldogsag.Text = Convert.ToString(Boldogsag);
        }

        private async void bt_Upgrade_Click(object sender, RoutedEventArgs e)
        {
            if (UpgradeCost <= Boldogsag)
            {

                Boldogsag = Boldogsag - UpgradeCost;
                UpgradeCost = UpgradeCost * 5;
                BPM = BPM * 2;

                txt_Boldogsag.Text = Convert.ToString(Boldogsag);
            }
            else
            {
                txt_Upgrades.Text = "Gyűjtögess még kicsit:)";
                // Késleltetés a szövegek között
                await Task.Delay(2000);
                txt_Upgrades.Text = "Fejlesztés:";
            }

            UpgradeCost = Math.Floor(UpgradeCost);
            bt_Upgrade.Content = "Szorzó: * 2\n\nÁr : " + UpgradeCost;

            txt_Boldogsag.Text = Convert.ToString(Boldogsag);
            txt_BPM.Text = "Dugong Boldogság / mp: " + BPM;
        }

        private async void bt_Feed_Click(object sender, RoutedEventArgs e)
        {
            if (FeedUpCost <= Boldogsag)
            {
                Boldogsag = Boldogsag - FeedUpCost;
                FeedUpCost = FeedUpCost * 1.5;
                BPM = BPM + BPM * 0.2;
                txt_Boldogsag.Text = Convert.ToString(Boldogsag);
            }
            else
            {
                txt_Upgrades.Text = "Gyűjtögess még kicsit:)";
                await Task.Delay(2000);
                txt_Upgrades.Text = "Fejlesztés:";
            }
            FeedUpCost = Math.Floor(FeedUpCost);
            bt_Feed.Content = "Szorzó: * 0.2\n\nÁr : " + FeedUpCost;

            txt_Boldogsag.Text = Convert.ToString(Boldogsag);
            txt_BPM.Text = "Dugong Boldogság / mp: " + BPM;
        }

        private async void bt_Premium_Click(object sender, RoutedEventArgs e)
        {
            if (PremiumUpCost <= Boldogsag)
            {
                Boldogsag = Boldogsag - PremiumUpCost;
                PremiumUpCost = PremiumUpCost * 3;
                BPM = BPM + BPM * .5;
                txt_Boldogsag.Text = Convert.ToString(Boldogsag);
            }
            else
            {
                txt_Upgrades.Text = "Gyűjtögess még kicsit:)";
                await Task.Delay(2000);
                txt_Upgrades.Text = "Fejlesztés:";
            }
            PremiumUpCost = Math.Floor(PremiumUpCost);
            bt_Premium.Content = "Szorzó: * 0.5\n\nÁr : " + PremiumUpCost;

            txt_Boldogsag.Text = Convert.ToString(Boldogsag);
            txt_BPM.Text = "Dugong Boldogság / mp: " + BPM;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow menu = new MainWindow();
            menu.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}