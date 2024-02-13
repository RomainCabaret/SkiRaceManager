using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SkiRaceManager.ViewModels
{
    internal class RankViewModel
    {
        public static List<string> GetAllRanks()
        {
            List<string> ranks = new List<string>();


            string query = $"SELECT * FROM `rank`";

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
                        string rank = reader.GetString(0);
                        ranks.Add(rank);
                    }
                    return ranks;
                }
            }
        }
    }
}
