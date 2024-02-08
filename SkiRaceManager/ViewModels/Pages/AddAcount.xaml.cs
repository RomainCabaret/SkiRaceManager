using MySql.Data.MySqlClient;
using SkiRaceManager.ViewModels.Pages;
using System;
using System.Collections.Generic;
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
    public partial class AddAcount : Page
    {
        public AddAcount()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO `account` (`login`, `password`, `profilePicture`, `rank`) VALUES (@login, @password, @profilePicture, @rank);";

            MySqlConnection connection = DbContext.CreateConnexion();
            connection.Open();

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                // Ajouter les paramètres avec leurs valeurs
                command.Parameters.AddWithValue("@login", inputLogin.Text);
                command.Parameters.AddWithValue("@password", inputPassword.Text);
                command.Parameters.AddWithValue("@profilePicture", "aa.jpg");
                command.Parameters.AddWithValue("@rank", comboBoxRank.Text);


                // Exécuter la requête
                int rowsAffected = command.ExecuteNonQuery();

                // Vérifier si des lignes ont été affectées pour confirmer l'insertion
                if (rowsAffected > 0)
                {
                    NavigationService.Navigate(new AdminViewModel());
                }
                else
                {
                    // Aucune ligne n'a été affectée, donc l'insertion a échoué
                    MessageBox.Show("l'insertion a échoué");
                }
            }

        }
    }
}
