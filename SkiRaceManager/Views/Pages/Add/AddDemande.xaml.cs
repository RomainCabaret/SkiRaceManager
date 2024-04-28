using Microsoft.Win32;
using MySql.Data.MySqlClient;
using SkiRaceManager.ViewModels.Pages;
using SkiRaceManager.ViewModels;
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
using SkiRaceManager.Models;

namespace SkiRaceManager.Views.Pages.Add
{
    /// <summary>
    /// Logique d'interaction pour AddDemande.xaml
    /// </summary>
    public partial class AddDemande : Page
    {
        public AddDemande()
        {
            InitializeComponent();
            foreach (var item in SlopeViewModel.GetAllSlope())
            {
                comboBoxRank.Items.Add(item);
            }
            comboBoxRank.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            string query = "INSERT INTO `request` (`id`, `dateDemande`, `isTraite`, `accountID`, `slopeID`) VALUES (NULL, @date, 0, @account, @slope);";

            MySqlConnection connection = DbContext.CreateConnexion();
            connection.Open();

            Slope slope = comboBoxRank.SelectedItem as Slope;

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                // Ajouter les paramètres avec leurs valeurs
                command.Parameters.AddWithValue("@date", DateTime.Now);
                command.Parameters.AddWithValue("@account", Session.Id);
                command.Parameters.AddWithValue("@slope", slope.SlopeID);


                // Exécuter la requête
                int rowsAffected = command.ExecuteNonQuery();

                // Vérifier si des lignes ont été affectées pour confirmer l'insertion
                if (rowsAffected > 0)
                {
                    NavigationService.Navigate(new RequestViewModel());
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
