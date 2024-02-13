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
    internal class SlopeViewModel
    {
        public static ObservableCollection<Slope> GetAllSlope()
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
    }
}
