using Microsoft.Win32;
using MySql.Data.MySqlClient;
using SkiRaceManager.Models;
using SkiRaceManager.ViewModels;
using SkiRaceManager.ViewModels.Pages;
using SkiRaceManager.Views.Pages.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class AddRequest : Page, INotifyPropertyChanged
    {

        private int RequestID { get; set; }
        private int SlopeID {  get; set; }

        private int UserID { get; set; }
        private string SlopeName { get; set; }
        private string SlopeImg { get; set; }

        private string _timeInput;

        public string TimeInput
        {
            get { return _timeInput; }
            set
            {
                if (_timeInput != value)
                {
                    _timeInput = value;
                    ValidateTimeInput();
                    OnPropertyChanged();
                }
            }
        }


        public AddRequest(int requestID, int slopeID, string slopeName, int userID)
        {
            InitializeComponent();
            this.RequestID = requestID;
            this.SlopeID = slopeID;
            this.SlopeName = slopeName;
            this.UserID = userID;
            DataContext = this;

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ParticipationViewModel.AddParticipationSlope(SlopeID, UserID, TimeSpan.Parse(inputTime.Text), DateTime.Now))
            {
                ChangeStateRequest();
                NavigationService.Navigate(new ViewGestionnaire());
            }
            else
            {
                MessageBox.Show("Error l'ajout à échoué ");
            }
        }
        private void ValidateTimeInput()
        {
            TimeSpan timeSpan;
            if (!TimeSpan.TryParseExact(TimeInput, "hh\\:mm\\:ss\\.fff", CultureInfo.InvariantCulture, out timeSpan))
            {
                MessageBox.Show("Le format du temps doit être hh:mm:ss.fff");
                TimeInput = "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ChangeStateRequest()
        {
            string query = "UPDATE `request` SET `isTraite` = '1' WHERE `request`.`id` = @id";

            MySqlConnection connection = DbContext.CreateConnexion();
            connection.Open();


            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                // Ajouter les paramètres avec leurs valeurs
                command.Parameters.AddWithValue("@id", RequestID);

                // Exécuter la requête
                int rowsAffected = command.ExecuteNonQuery();

                // Vérifier si des lignes ont été affectées pour confirmer la mise à jour


            }
        }
    }
}
