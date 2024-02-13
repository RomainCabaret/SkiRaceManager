using SkiRaceManager.Models;
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

namespace SkiRaceManager.ViewModels.Pages
{
    /// <summary>
    /// Logique d'interaction pour HomeViewModel.xaml
    /// </summary>
    public partial class HomeViewModel : Page
    {
        private static ObservableCollection<Slope> slopes {get; set;}
        public HomeViewModel()
        {
            InitializeComponent();
            slopes = SlopeViewModel.GetAllSlope();
            FillContainersToGrid();

        }
        private void FillContainersToGrid()
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

            int numberOfRows = (int)Math.Ceiling((double)slopes.Count() / numberOfColumns);

            foreach (Slope slope in slopes)
            {
                Border container = new Border();
                container.Background = new SolidColorBrush(Color.FromRgb(46, 45, 50));
                container.BorderBrush = Brushes.Black;
                container.BorderThickness = new Thickness(1);
                container.Height = 500;

                TextBlock textBlock = new TextBlock();
                textBlock.Text = $"{slope.Name}";
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.FontSize = 20;
                textBlock.Foreground = Brushes.White; // Utiliser Brushes.White pour la couleur blanche

                Image image = new Image();
                ImageViewModel.ChargerImage(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", slope.Image), image);
                image.Width = double.NaN;
                image.HorizontalAlignment = HorizontalAlignment.Stretch;
                image.Stretch = Stretch.UniformToFill; // Définir la propriété Stretch sur UniformToFill

                // Liaison (binding) à la largeur du conteneur parent
                Binding binding = new Binding("ActualWidth");
                binding.RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Border), 1);
                image.SetBinding(Image.WidthProperty, binding);
                image.Height = 60;


                TextBlock textBlockParticipation = new TextBlock();
                textBlockParticipation.Text = $"Couleur : {slope.Color}";
                textBlockParticipation.FontSize = 15;
                textBlockParticipation.Foreground = Brushes.White;


                TextBlock textBlockBestTime = new TextBlock();
                textBlockBestTime.Text = $"Meilleurs temps : {"2:00:11"}";
                textBlockBestTime.FontSize = 15;
                textBlockBestTime.Foreground = Brushes.White;

                Button button = new Button();
                button.Background = new SolidColorBrush(Color.FromRgb(50, 230, 183));
                button.Content = "En savoir plus";
                button.FontSize = 15;
                Binding bindingBtn = new Binding("ActualWidth");
                bindingBtn.RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Border), 1);
                button.SetBinding(Button.WidthProperty, bindingBtn);
                button.Click += (sender, e) =>
                {
                    // Naviguer vers la nouvelle page
                    //NavigationService?.Navigate(new Uri("InformationsSlopePage.xaml", UriKind.Relative));
                    MessageBox.Show($"{slope.Name}");

                };

                // Ajouter le TextBlock et l'Image au conteneur
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Vertical; // changer l'orientation en vertical
                stackPanel.Children.Add(image); // Ajouter l'image en premier
                stackPanel.Children.Add(textBlock); // Ajouter le TextBlock après
                stackPanel.Children.Add(textBlockParticipation);
                stackPanel.Children.Add(textBlockBestTime);
                stackPanel.Children.Add(button);


                container.Child = stackPanel;

                mainGrid.Children.Add(container);

                columnCounter++;
                if (columnCounter > numberOfColumns - 1)
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
                FillContainersToGrid();

            }
            catch (Exception)
            {
                Console.WriteLine("Error bad search");
            }
        }
    }
}
