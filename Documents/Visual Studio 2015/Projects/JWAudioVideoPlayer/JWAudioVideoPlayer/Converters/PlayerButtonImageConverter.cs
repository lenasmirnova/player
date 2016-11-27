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
                case "PAUZA":
                    return "F1 M 26.9167,23.75L 33.25,23.75L 33.25,52.25L 26.9167,52.25L 26.9167,23.75 Z M 42.75,23.75L 49.0833,23.75L 49.0833,52.25L 42.75,52.25L 42.75,23.75 Z ";
                case "STOP":
                    return "F1 M 0,0L 76,0L 76,76L 0,76L 0,0";
                case "DO PRZODU":
                    return "F1 M 19,25L 35.75,38L 19,51L 19,25 Z M 41,25L 57.75,38L 41,51L 41,25 Z ";
                case "DO TYŁU":
                    return "F1 M 57,25L 40.25,38L 57,51L 57,25 Z M 35,25L 18.25,38L 35,51L 35,25 Z ";
                case "ZERUJ":
                    return "";
                case "OPEN":
                    return "F1 M 19,50L 28,34L 63,34L 54,50L 19,50 Z M 19,28.0001L 35,28C 36,25 37.4999,24.0001 37.4999,24.0001L 48.75,24C 49.3023,24 50,24.6977 50,25.25L 50,28L 53.9999,28.0001L 53.9999,32L 27,32L 19,46.4L 19,28.0001 Z ";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
