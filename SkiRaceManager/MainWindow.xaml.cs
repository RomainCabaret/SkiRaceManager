using SkiRaceManager.Models;
using SkiRaceManager.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SkiRaceManager
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LoginViewModel.ConnectUser(inputLogin.Text, inputPassword.Password.ToString()))
                {
                    Home home = new Home();
                    home.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Identification échoué");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("La base de données semble avoir un probleme");
            }
        }

    }
}
