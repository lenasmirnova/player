using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace JWAudioVideoPlayer.Converters
{
    public class ProjectorContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            if (parameter == null)
                throw new ArgumentNullException("parameter");

            string stringValue = value.ToString();
            string stringParameter = parameter.ToString();

            if (stringValue.Equals(stringParameter))
                return Visibility.Visible;

            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
