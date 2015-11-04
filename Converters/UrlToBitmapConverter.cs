using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IKinea.Converters
{
    public class UrlToBitmapConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string path = value as string;
            if (string.IsNullOrEmpty(path)) return null;
            if (path.StartsWith("http"))
                return new BitmapImage(new Uri(value as string, UriKind.Absolute));
            else
                return new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), (value as string).Replace("\\", "/"))));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
