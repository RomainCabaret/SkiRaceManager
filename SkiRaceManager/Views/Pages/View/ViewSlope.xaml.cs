using SkiRaceManager.Models;
using SkiRaceManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SkiRaceManager.Views.Pages.View
{
    /// <summary>
    /// Logique d'interaction pour ViewSlope.xaml
    /// </summary>
    public partial class ViewSlope : Page
    {
        private int SlopeID {  get; set; }
        private string SlopeName { get; set; }
        private string SlopeImg { get; set; }

        private ObservableCollection<Participation> participations { get; set; }

        public ViewSlope(int slopeID, string slopeName, string slopeImg)
        {
            InitializeComponent();
            SlopeID = slopeID;
            SlopeName = slopeName;
            SlopeImg = slopeImg;

            participations = SlopeViewModel.GetParticipations(slopeID);

            ImageViewModel.ChargerImage(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", slopeImg), votreImageControl);
            textTitle.Text = slopeName;

            ParticipationListView.ItemsSource = participations;

        }

        private void ParticipationListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Participation selectedParticipant = (Participation)ParticipationListView.SelectedItem;
   
            if (selectedParticipant != null)
            {
                MessageBox.Show(selectedParticipant.AccountPictureFullPath);
            }
        }

        private void btnAddParticipation(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddParticipation(SlopeID, SlopeName, SlopeImg));
        }

        private void btnSearchParticipation(object sender, RoutedEventArgs e)
        {
            participations = ParticipationViewModel.SearchParticipations(SlopeID, inputName.Text);
            ParticipationListView.ItemsSource = participations;
            Colorise();
        }

        private void ViewSlope_Loaded(object sender, RoutedEventArgs e)
        {
            Colorise();
        }
        private void Colorise()
        {
            // Parcourir les éléments de la ListView pour définir les couleurs en fonction du classement
            for (int i = 0; i < ParticipationListView.Items.Count; i++)
            {
                var item = ParticipationListView.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                if (item != null)
                {
                    // Obtenez le classement de l'élément
                    int rank = i + 1;

                    // Définir la couleur en fonction du classement
                    switch (rank)
                    {
                        case 1:
                            item.Background = Brushes.Gold;
                            break;
                        case 2:
                            item.Background = Brushes.Silver;
                            break;
                        case 3:
                            item.Background = Brushes.Brown;
                            break;
                        default:
                            item.Foreground = Brushes.Black; // Couleur par défaut pour les autres rangs
                            break;
                    }
                }
            }
        }
    }
}
