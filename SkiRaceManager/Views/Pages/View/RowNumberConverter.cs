using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace SkiRaceManager
{
    public class RowNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ListViewItem item)
            {
                ListView listView = ItemsControl.ItemsControlFromItemContainer(item) as ListView;
                if (listView != null)
                {
                    int index = listView.ItemContainerGenerator.IndexFromContainer(item);
                    return index + 1;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
