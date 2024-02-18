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

        public static ObservableCollection<Participation> GetParticipations(int slopeID)
        {
            ObservableCollection<Participation> participations = new ObservableCollection<Participation>();

            string query = "SELECT a.profilePicture, a.login, p.time, P.date FROM `participations` p INNER JOIN account a ON p.accountid = a.id WHERE p.`slopeid` = @id ORDER BY p.time";
            MySqlConnection connection = DbContext.CreateConnexion();


            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", slopeID);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Parcourir les lignes de données
                    while (reader.Read())
                    {
                        // Récupérer les valeurs des colonnes de la ligne actuelle
                        string picturePath = reader["profilePicture"].ToString();
                        string accountLogin = reader["login"].ToString();
                        string time = reader["time"].ToString();
                        string date = reader["date"].ToString();

                        Participation participation = new Participation { AccountLogin = accountLogin, AccountPicture = picturePath, Time = TimeSpan.Parse(time), ReleaseDate = Convert.ToDateTime(date) };
                        participations.Add(participation);
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Erreur : " + ex.Message);
            }


            return participations;
        }
    }
}
