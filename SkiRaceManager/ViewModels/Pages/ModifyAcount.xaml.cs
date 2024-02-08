using MySql.Data.MySqlClient;
using SkiRaceManager.Models;
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
    public partial class ModifyAcount : Page
    {
        private int currentID {  get; set; }

        public ModifyAcount(int id, string login, string password, string picture, string rank)
        {
            InitializeComponent();
            this.currentID = id;
            inputLogin.Text = login;
            inputPassword.Text = password;

            if (!string.IsNullOrEmpty(rank))
            {
                // Recherchez l'élément correspondant dans la ComboBox
                foreach (ComboBoxItem item in comboBoxRank.Items)
                {
                    if (item.Content.ToString() == rank)
                    {
                        comboBoxRank.SelectedItem = item;
                        break;
                    }
                }
            }


        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string query = $"UPDATE `account` SET `login` = @login, `password` = @password, `profilePicture` = @profilePicture, `rank` = @rank WHERE `account`.`id` = @id;";

            MySqlConnection connection = DbContext.CreateConnexion();
            connection.Open();

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                // Ajouter les paramètres avec leurs valeurs
                command.Parameters.AddWithValue("@login", inputLogin.Text);
                command.Parameters.AddWithValue("@password", inputPassword.Text);
                command.Parameters.AddWithValue("@profilePicture", "new_profile_picture.jpg");
                command.Parameters.AddWithValue("@rank", comboBoxRank.Text);
                command.Parameters.AddWithValue("@id", currentID); // Assurez-vous de définir correctement currentID

                // Exécuter la requête
                int rowsAffected = command.ExecuteNonQuery();

                // Vérifier si des lignes ont été affectées pour confirmer la mise à jour
                if (rowsAffected > 0)
                {
                    // Mise à jour réussie, vous pouvez effectuer d'autres opérations si nécessaire
                    NavigationService.Navigate(new AdminViewModel());
                }
                else
                {
                    // Aucune mise à jour effectuée (peut-être que l'ID n'a pas été trouvé)
                    MessageBox.Show("La mise à jour a échoué");
                }
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Demander confirmation à l'utilisateur avant de supprimer
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet utilisateur ?", "Confirmation de suppression", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                string query = "DELETE FROM `account` WHERE `id` = @id;";

                MySqlConnection connection = DbContext.CreateConnexion();
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Ajouter le paramètre ID avec sa valeur
                    command.Parameters.AddWithValue("@id", currentID); // Assurez-vous de définir correctement currentID

                    // Exécuter la requête
                    int rowsAffected = command.ExecuteNonQuery();

                    // Vérifier si des lignes ont été affectées pour confirmer la suppression
                    if (rowsAffected > 0)
                    {
                        // Suppression réussie
                        NavigationService.Navigate(new AdminViewModel());
                    }
                    else
                    {
                        // Aucune suppression effectuée (peut-être que l'ID n'a pas été trouvé)
                        MessageBox.Show("La suppression a échoué.");
                    }
                }
            }
        }







    }
}
