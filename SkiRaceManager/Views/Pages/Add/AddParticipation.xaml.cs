using Microsoft.Win32;
using MySql.Data.MySqlClient;
using SkiRaceManager.Models;
using SkiRaceManager.ViewModels;
using SkiRaceManager.ViewModels.Pages;
using SkiRaceManager.Views.Pages.View;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour Participation.xaml
    /// </summary>
    public partial class AddParticipation : Page
    {
        private int SlopeID {  get; set; }
        private string SlopeName { get; set; }
        private string SlopeImg { get; set; }


        public AddParticipation(int slopeID, string slopeName, string slopeImg)
        {
            InitializeComponent();
            this.SlopeID = slopeID;
            this.SlopeName = slopeName;
            this.SlopeImg = slopeImg;
            
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ParticipationViewModel.AddParticipationSlope(SlopeID, Session.Id, TimeSpan.Parse(inputTime.Text), DateTime.Now))
            {
                NavigationService.Navigate(new ViewSlope(SlopeID, SlopeName, SlopeImg));
            }
            else
            {
                MessageBox.Show("Error l'ajout à échoué ");
            }
        }
    }
}
