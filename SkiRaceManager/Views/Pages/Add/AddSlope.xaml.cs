﻿using Microsoft.Win32;
using MySql.Data.MySqlClient;
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
    public partial class AddSlope : Page
    {
        private string slopePictureName = "defaultSlope.png";
        public AddSlope()
        {
            InitializeComponent();
            List<string> colors = ColorViewModel.GetAllColors();
            foreach (var element in colors)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = element;
                comboBoxColors.Items.Add(item);
            }
            comboBoxColors.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO `slope` (`name`, `color`, `image`) VALUES (@name, @color, @image);";

            MySqlConnection connection = DbContext.CreateConnexion();
            connection.Open();

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                // Ajouter les paramètres avec leurs valeurs
                command.Parameters.AddWithValue("@name", inputName.Text);
                command.Parameters.AddWithValue("@color", comboBoxColors.Text);
                command.Parameters.AddWithValue("@image", slopePictureName);


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
        private void btnUploadImg(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers image (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|Tous les fichiers (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string cheminImage = openFileDialog.FileName;

                string nomImage = System.IO.Path.GetFileName(cheminImage);
                slopePictureName = nomImage;

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