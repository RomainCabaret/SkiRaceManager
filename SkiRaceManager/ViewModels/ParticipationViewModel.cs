using MySql.Data.MySqlClient;
using SkiRaceManager.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Windows;
using SkiRaceManager.Models;
using System.Collections.ObjectModel;

namespace SkiRaceManager.ViewModels
{
    internal class ParticipationViewModel
    {
        public static ObservableCollection<Participation> SearchParticipations(int slopeID, string search)
        {
            ObservableCollection<Participation> participations = new ObservableCollection<Participation>();

            string query = "SELECT a.profilePicture, a.login, p.time, P.date FROM `participations` p INNER JOIN account a ON p.accountid = a.id WHERE p.`slopeid` AND a.login LIKE @user = @id ORDER BY p.time";
            MySqlConnection connection = DbContext.CreateConnexion();


            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", slopeID);
                command.Parameters.AddWithValue("@user", "%" + search + "%");

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
        public static bool AddParticipationSlope(int slopeID, int accountID, TimeSpan time, DateTime releaseDate )
        {
            string query = "INSERT INTO `participations` (`slopeid`, `accountid`, `time`, `date`) VALUES (@slope, @account, @time, @date)";

            MySqlConnection connection = DbContext.CreateConnexion();
            connection.Open();

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                // Ajouter les paramètres avec leurs valeurs
                command.Parameters.AddWithValue("@slope", slopeID);
                command.Parameters.AddWithValue("@account", accountID);
                command.Parameters.AddWithValue("@time", time);
                command.Parameters.AddWithValue("@date", releaseDate);


                // Exécuter la requête
                int rowsAffected = command.ExecuteNonQuery();

                // Vérifier si des lignes ont été affectées pour confirmer l'insertion
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    // Aucune ligne n'a été affectée, donc l'insertion a échoué
                    return false;
                }
            }
        }
    }
}
