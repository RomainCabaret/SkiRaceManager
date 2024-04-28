using MySql.Data.MySqlClient;
using SkiRaceManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Notice.Frame.Types;

namespace SkiRaceManager.ViewModels
{
    internal class SlopeViewModel
    {
        public static ObservableCollection<Slope> GetAllSlope()
        {
            ObservableCollection<Slope> slopes = new ObservableCollection<Slope>();

            string query = "SELECT s.*, COUNT(p.time) AS runCount FROM `slope` s LEFT JOIN participations p ON s.id = p.slopeid GROUP BY s.id";
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
                        int runCount = int.Parse(reader["runCount"].ToString());

                        Slope slope = new Slope { SlopeID = id, Name = name, Color = color, Image = img, RunCount = runCount};
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

            string query = "SELECT p.id, a.profilePicture, a.login, p.time, P.date FROM `participations` p INNER JOIN account a ON p.accountid = a.id WHERE p.`slopeid` = @id ORDER BY p.time";
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
                        int id = int.Parse(reader["id"].ToString());
                        string picturePath = reader["profilePicture"].ToString();
                        string accountLogin = reader["login"].ToString();
                        string time = reader["time"].ToString();
                        string date = reader["date"].ToString();

                        Participation participation = new Participation { Id = id, AccountLogin = accountLogin, AccountPicture = picturePath, Time = TimeSpan.Parse(time), ReleaseDate = Convert.ToDateTime(date) };
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
        public static ObservableCollection<Slope> SearchSlopes(string search, string slopeColor)
        {
            ObservableCollection<Slope> slopes = new ObservableCollection<Slope>();

            string query = "SELECT s.*, COUNT(p.time) AS runCount FROM `slope` s LEFT JOIN participations p ON s.id = p.slopeid WHERE name LIKE @slopeName AND (color = @color OR @color = '') GROUP BY s.id";
            MySqlConnection connection = DbContext.CreateConnexion();


            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@slopeName", "%" + search + "%");
                command.Parameters.AddWithValue("@color", slopeColor);

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
                        int runCount = int.Parse(reader["runCount"].ToString());


                        Slope slope = new Slope { SlopeID = id, Name = name, Color = color, Image = img, RunCount = runCount};
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
