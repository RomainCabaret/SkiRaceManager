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

namespace SkiRaceManager.ViewModels.Pages
{
    /// <summary>
    /// Logique d'interaction pour HomeViewModel.xaml
    /// </summary>
    public partial class HomeViewModel : Page
    {
        public HomeViewModel()
        {
            InitializeComponent();
            FillContainersToGrid(5);
        }
        private void FillContainersToGrid(int numberOfContainers)
        {
            int numberOfColumns = 3;
            int columnCounter = -1;
            int rowCounter = 0;


            mainGrid.Children.Clear();
            mainGrid.RowDefinitions.Clear();
            mainGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < numberOfColumns; i++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                mainGrid.ColumnDefinitions.Add(columnDefinition);
                
            }

            int numberOfRows = (int)Math.Ceiling((double)numberOfContainers / numberOfColumns);

            for (int i = 0; i < numberOfContainers; i++)
            {
                Border container = new Border();
                container.Background = new SolidColorBrush(Color.FromRgb(46, 45, 50));
                container.BorderBrush = Brushes.Black;
                container.BorderThickness = new Thickness(1);
                container.Height = 50;

                TextBlock textBlock = new TextBlock();
                textBlock.Text = $"My Containe {i + 1}";

                container.Child = textBlock;

                mainGrid.Children.Add(container);

                columnCounter++;
                if(columnCounter > numberOfColumns - 1)
                {
                    columnCounter = 0;
                    rowCounter++;
                }

                // Spécifier la colonne et la ligne pour le conteneur
                Grid.SetColumn(container, columnCounter);
                Grid.SetRow(container, rowCounter);
            }

            // Ajouter des lignes supplémentaires si nécessaire
            for (int i = 0; i < numberOfRows; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(150, GridUnitType.Pixel);
                mainGrid.RowDefinitions.Add(rowDefinition);
            }

            ScrollViewer scrollViewer = new ScrollViewer
            {
                Content = mainGrid,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            };
            scrollViewer.Content = mainGrid;
        }
        private void btnSearch(object sender, RoutedEventArgs e)
        {
            try
            {
                FillContainersToGrid(int.Parse(inputSearch.Text));

            }
            catch (Exception)
            {
                Console.WriteLine("Error bad search");
            }
        }
    }
}
