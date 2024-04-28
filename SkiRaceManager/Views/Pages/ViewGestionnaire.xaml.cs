using MySql.Data.MySqlClient;
using SkiRaceManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ViewGestionnaire : Page
    {
        public ViewGestionnaire()
        {
            InitializeComponent();
            ObservableCollection<Request> requests = GetAllRequests();
            RequestListView.ItemsSource = requests;
        }
        private ObservableCollection<Request> GetAllRequests()
        {
            ObservableCollection<Request> requests = new ObservableCollection<Request>();

            string query = "SELECT r.*, s.name, a.login FROM `request` r INNER JOIN slope s ON r.slopeID = s.id INNER JOIN account a ON r.accountID = a.id WHERE `r`.`slopeID` IN (SELECT m.slopeID FROM `manager` m WHERE m.accountID = @id)";
            MySqlConnection connection = DbContext.CreateConnexion();


            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", Session.Id); // Assurez-vous de définir correctement currentID
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Parcourir les lignes de données
                    while (reader.Read())
                    {
                        // Récupérer les valeurs des colonnes de la ligne actuelle
                        int id = int.Parse(reader["id"].ToString());
                        int slopeID = int.Parse(reader["slopeID"].ToString());
                        string slopeName = reader["name"].ToString();
                        string accountName = reader["login"].ToString();

                        DateTime dateRequete = Convert.ToDateTime(reader["dateDemande"]);
                        bool isTraite = Convert.ToBoolean(reader["isTraite"]);

                        Request request = new Request { Id = id, AccountID = Session.Id, SlopeID = slopeID, SlopeName = slopeName, AccountName = accountName, DateDemande = dateRequete, IsTraite = isTraite };
                        requests.Add(request);
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erreur : " + ex.Message);
            }

            return requests;
        }
        private static ObservableCollection<Slope> GetAllSlope()
        {
            ObservableCollection<Slope> slopes = new ObservableCollection<Slope>();

            string query = "SELECT * FROM `slope`";
            MySqlConnection connection = DbContext.CreateConnexion();


            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Parcourir les lignes de données
                    while (reader.Read())
                    {
                        // Récupérer les valeurs des colonnes de la ligne actuelle
                        int id = int.Parse(reader["id"].ToString());
                        string name = reader["name"].ToString();
                        string color = reader["color"].ToString();
                        string img = reader["image"].ToString();

                        Slope slope = new Slope { SlopeID = id, Name = name, Color = color, Image = img };
                        slopes.Add(slope);
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erreur : " + ex.Message);
            }

            return slopes;
        }



        private void btnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAcount());
        }

        private void btnAddSlope_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSlope());
        }

        private void Account_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            //Accounts selectedClient = (Accounts)AccountListView.SelectedItem;
            //if (selectedClient != null)
            //{

            //    NavigationService.Navigate(new ModifyAcount(selectedClient.Id, selectedClient.Login, selectedClient.Password, selectedClient.ProfilePicture, selectedClient.Rank));
            //}
        }

        private void Slope_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Slope selectedSlopes = (Slope)SlopeListView.SelectedItem;
            //if (selectedSlopes != null)
            //{
            //    NavigationService.Navigate(new ModifySlope(selectedSlopes.SlopeID, selectedSlopes.Name, selectedSlopes.Color, selectedSlopes.Image));
            //}
        }

        private void RequestListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Request selectedRequest = (Request)RequestListView.SelectedItem;
            if(selectedRequest != null)
            {
                NavigationService.Navigate(new AddRequest(selectedRequest.Id, selectedRequest.SlopeID, selectedRequest.SlopeName, selectedRequest.AccountID));
            }
        }
    }
}
