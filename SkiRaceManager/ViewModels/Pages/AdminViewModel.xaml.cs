using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace SkiRaceManager.ViewModels.Pages
{
    /// <summary>
    /// Logique d'interaction pour HomeViewModel.xaml
    /// </summary>
    public partial class AdminViewModel : Page
    {
        public AdminViewModel()
        {
            InitializeComponent();

            // RECUPERE
            ObservableCollection<Slope> slopes = GetAllSlope();
            ObservableCollection<Accounts> accounts = GetAllAccount();


            // Ajout des données à la liste view
            SlopeListView.ItemsSource = slopes;
            AccountListView.ItemsSource = accounts;


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

        private static ObservableCollection<Accounts> GetAllAccount()
        {
            ObservableCollection<Accounts> accounts = new ObservableCollection<Accounts>();

            string query = "SELECT * FROM `account`";
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
                        string login = reader["login"].ToString();
                        string password = reader["password"].ToString();
                        string img = reader["profilePicture"].ToString();
                        string rank = reader["rank"].ToString();


                        Accounts account = new Accounts { Id = id, Login = login, Password = password, ProfilePicture = img, Rank = rank};
                        accounts.Add(account);
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erreur : " + ex.Message);
            }

            return accounts;
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

            Accounts selectedClient = (Accounts)AccountListView.SelectedItem;
            if (selectedClient != null)
            {

                NavigationService.Navigate(new ModifyAcount(selectedClient.Id, selectedClient.Login, selectedClient.Password, selectedClient.ProfilePicture, selectedClient.Rank));
            }
        }

        
    }
}
