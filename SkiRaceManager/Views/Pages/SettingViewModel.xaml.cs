using Microsoft.Win32;
using MySql.Data.MySqlClient;
using SkiRaceManager.Models;
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

namespace SkiRaceManager.ViewModels.Pages
{
    /// <summary>
    /// Logique d'interaction pour HomeViewModel.xaml
    /// </summary>
    public partial class SettingViewModel : Page
    {
        public SettingViewModel()
        {
            InitializeComponent();
            inputLogin.Text = Session.Login;
            inputPassword.Text = Session.Password;
            if (!string.IsNullOrEmpty(Session.ProfilePicture))
            {
                string cheminCompletDestination = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", Session.ProfilePicture);

                ChargerImage(cheminCompletDestination);
                
            }
        }
        public static bool ModifyUser(string newLogin, string newPassword, string newPP, int currentID )
        {
            string query = $"UPDATE `account` SET `login` = @login, `password` = @password, `profilePicture` = @profilePicture WHERE `account`.`id` = @id;";

            MySqlConnection connection = DbContext.CreateConnexion();
            connection.Open();


            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                // Ajouter les paramètres avec leurs valeurs
                command.Parameters.AddWithValue("@login", newLogin);
                command.Parameters.AddWithValue("@password", newPassword);
                command.Parameters.AddWithValue("@profilePicture", newPP);
                command.Parameters.AddWithValue("@id", currentID);

                // Exécuter la requête
                int rowsAffected = command.ExecuteNonQuery();

                // Vérifier si des lignes ont été affectées pour confirmer la mise à jour
                if (rowsAffected > 0)
                {
                    Session.Login = newLogin;
                    Session.Password = newPassword;
                    Session.ProfilePicture = newPP;

                    return true;
                }
                else
                {
                    // Aucune mise à jour effectuée (peut-être que l'ID n'a pas été trouvé)
                    return false;
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

        private void BtnModify_Click(object sender, EventArgs e)
        {
            string imageFileName = System.IO.Path.GetFileName(votreImageControl.Source.ToString());
            if (ModifyUser(inputLogin.Text, inputPassword.Text, imageFileName, Session.Id))
            {
                //NavigationService.Navigate(new SettingViewModel());
                MessageBox.Show("Parametre mise à jours ! ");
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }

        private void BtnDisconnected_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
    }
}
