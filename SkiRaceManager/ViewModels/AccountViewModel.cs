using MySql.Data.MySqlClient;
using SkiRaceManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRaceManager.ViewModels
{
    internal class AccountViewModel
    {
        public static ObservableCollection<Accounts> GetAllGestionnaire()
        {
            ObservableCollection<Accounts> accounts = new ObservableCollection<Accounts>();

            string query = "SELECT * FROM `account` WHERE `rank` IN ('admin', 'gestionnaire')";
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


                        Accounts account = new Accounts { Id = id, Login = login, Password = password, ProfilePicture = img, Rank = rank };
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

    }
}
