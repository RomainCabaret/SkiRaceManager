using SkiRaceManager.Models;
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

namespace SkiRaceManager.Views.Pages.Add
{
    /// <summary>
    /// Logique d'interaction pour AddGestionnaire.xaml
    /// </summary>
    public partial class AddManager : Page
    {
        private Slope slope {  get; set; }
        public AddManager(Slope slope)
        {
            InitializeComponent();
            this.slope = slope;
            foreach (var item in ManagerViewModel.GetNotManagerSlope(slope.SlopeID))
            {
                comboManager.Items.Add(item);
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(comboManager.SelectedItem != null)
            {
                Accounts account = comboManager.SelectedItem as Accounts;
                if(ManagerViewModel.AddSlopeManager(slope.SlopeID, account.Id))
                {
                    NavigationService.Navigate(new ModifySlope(slope.SlopeID, slope.Name, slope.Color, slope.Image));
                }
                
            }
        }
    }
}
