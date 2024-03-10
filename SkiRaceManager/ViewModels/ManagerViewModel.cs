using MaterialDesignColors;
using MySql.Data.MySqlClient;
using SkiRaceManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace SkiRaceManager.ViewModels
{
    internal class ManagerViewModel
    {
        public static ObservableCollection<Accounts> GetManagerSlope(int slopeID)
        {
            ObservableCollection<Accounts> managers = new ObservableCollection<Accounts>();

            string query = "SELECT a.* FROM `manager` INNER JOIN account a ON `accountID` = a.id WHERE `slopeID` = @slope";
            MySqlConnection connection = DbContext.CreateConnexion();


            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@slope", slopeID);

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


                        Accounts account = new Accounts { Id = id, Login = login, Password = password, ProfilePicture = img, Rank = rank };
                        managers.Add(account);
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erreur : " + ex.Message);
            }

            return managers;
        }
        public static ObservableCollection<Accounts> GetNotManagerSlope(int slopeID)
        {
            ObservableCollection<Accounts> managers = new ObservableCollection<Accounts>();

            string query = "SELECT a.* FROM account a LEFT JOIN manager m ON a.id = m.accountID AND m.slopeID = @slope WHERE m.accountID IS NULL AND `rank` IN ('admin', 'gestionnaire')";
            MySqlConnection connection = DbContext.CreateConnexion();


            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@slope", slopeID);

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


                        Accounts account = new Accounts { Id = id, Login = login, Password = password, ProfilePicture = img, Rank = rank };
                        managers.Add(account);
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erreur : " + ex.Message);
            }

            return managers;
        }
        public static bool AddSlopeManager(int slopeID, int accountID)
        {
            try
            {
                string query = "INSERT INTO `manager` (`slopeID`, `accountID`) VALUES (@slope, @account);";

                MySqlConnection connection = DbContext.CreateConnexion();
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Ajouter les paramètres avec leurs valeurs
                    command.Parameters.AddWithValue("@slope", slopeID);
                    command.Parameters.AddWithValue("@account", accountID);


                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
