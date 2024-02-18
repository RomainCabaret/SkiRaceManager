using SkiRaceManager.Models;
using SkiRaceManager.ViewModels.Pages;
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

namespace SkiRaceManager
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private static string rank = Session.Rank;
        public Home()
        {
            InitializeComponent();
            if(rank.ToLower() == "admin")
            {
                btnModeration.Visibility = Visibility.Visible;
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {

            homeFrame.Navigate(new HomeViewModel());
        }

        private void btnParticipation_Click(object sender, RoutedEventArgs e)
        {
            homeFrame.Navigate(new ViewParticipation());
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            homeFrame.Navigate(new AdminViewModel());
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            homeFrame.Navigate(new SettingViewModel());
        }
    }
}
