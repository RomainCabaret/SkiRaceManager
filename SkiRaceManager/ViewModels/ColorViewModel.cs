using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRaceManager.ViewModels
{
    internal class ColorViewModel
    {
        public static List<string> GetAllColors()
        {
            List<string> colors = new List<string>();


            string query = $"SELECT color FROM `color`";

            MySqlConnection connection = DbContext.CreateConnexion();
            connection.Open();


            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                // Ajouter les paramètres avec leurs valeurs


                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Parcourir les lignes de données

                    while (reader.Read())
                    {
                        string color = reader.GetString(0);
                        colors.Add(color);
                    }
                    return colors;
                }
            }
        }
    }
}
