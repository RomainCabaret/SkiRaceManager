using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace SkiRaceManager
{
    public class RankToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int rank && Application.Current != null && Application.Current.MainWindow != null)
            {
                var mainWindow = Application.Current.MainWindow;
                var resource = mainWindow.FindResource($"RankColor{rank}");
                if (resource is SolidColorBrush brush)
                {
                    return brush;
                }
            }

            return Brushes.Black; // Par défaut, renvoie noir
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
