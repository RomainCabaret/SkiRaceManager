using Microsoft.Win32;
using MySql.Data.MySqlClient;
using SkiRaceManager.Models;
using SkiRaceManager.ViewModels;
using SkiRaceManager.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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
        private string profilePictureName { get; set; }


        public ModifyAcount(int id, string login, string password, string picture, string rank)
        {
            InitializeComponent();
            this.currentID = id;
            inputLogin.Text = login;
            inputPassword.Text = password;
            profilePictureName = picture;

            ChargerImage(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", picture));


            List<string> ranks = RankViewModel.GetAllRanks();
            foreach (var element in ranks)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = element;
                comboBoxRank.Items.Add(item);
            }
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
                command.Parameters.AddWithValue("@profilePicture", profilePictureName);
                command.Parameters.AddWithValue("@rank", comboBoxRank.Text);
                command.Parameters.AddWithValue("@id", currentID); // Assurez-vous de définir correctement currentID

                // Exécuter la requête

                if(Session.Id == currentID)
                {
                    MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier votre compte ?", "Confirmation de suppression", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }

                }

                int rowsAffected = command.ExecuteNonQuery();

                // Vérifier si des lignes ont été affectées pour confirmer la mise à jour
                if (rowsAffected > 0)
                {
                    if(Session.Id == currentID)
                    {
                        Session.Login = inputLogin.Text;
                        Session.Password = inputPassword.Text;
                        Session.ProfilePicture = profilePictureName;
                        Session.Rank = comboBoxRank.Text;
                    }
                    
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
            if (Session.Id == currentID)
            {
                MessageBox.Show("Attention cela supprimera votre propre compte !");
            }
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
                        // Suppression de sont propre compte
                        if (Session.Id == currentID)
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            Window.GetWindow(this).Close();
                            return;
                        }
                        // Suppression d'un compte autre
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
        private void btnUploadImg(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers image (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|Tous les fichiers (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string cheminImage = openFileDialog.FileName;

                string nomImage = System.IO.Path.GetFileName(cheminImage);
                profilePictureName = nomImage;

                string cheminCompletDestination = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", nomImage);

                try
                {
                    File.Copy(cheminImage, cheminCompletDestination, true);

                    ChargerImage(cheminCompletDestination);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"Une erreur s'est produite lors de l'enregistrement de l'image : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (File.Exists(cheminCompletDestination))
                    {
                        Uri uri = new Uri(cheminCompletDestination);
                        ImageSource source = new BitmapImage(uri);
                        votreImageControl.Source = source;
                    }
                }
            }
        }

        private void ChargerImage(string cheminCompletDestination)
        {
            try
            {
                if (File.Exists(cheminCompletDestination))
                {
                    Uri uri = new Uri(cheminCompletDestination);
                    ImageSource source = new BitmapImage(uri);
                    votreImageControl.Source = source;
                }
                else
                {
                    MessageBox.Show($"L'image {cheminCompletDestination} n'a pas pu être chargée dans le répertoire de destination.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors du chargement ou de la copie de l'image : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
