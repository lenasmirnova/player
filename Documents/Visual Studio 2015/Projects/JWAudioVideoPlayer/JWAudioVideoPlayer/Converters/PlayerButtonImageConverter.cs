using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JWAudioVideoPlayer.Converters
{
    public class PlayerButtonImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = value as string;

            switch (stringValue)
            {
                case "START":
                    return "F1 M 30.0833,22.1667L 50.6665,37.6043L 50.6665,38.7918L 30.0833,53.8333L 30.0833,22.1667 Z ";
                case "":
                    return "";
            }
            return string.Empty;        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
