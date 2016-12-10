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
                case "ZEGAR":
                    return "F1 M 53.8333,41.1667C 53.8333,49.9112 46.7445,57 38,57C 29.2555,57 22.1667,49.9112 22.1667,41.1667C 22.1667,32.9565 28.4156,26.2059 36.4167,25.4115L 36.4167,23.75L 31.6667,23.75L 31.6667,19L 44.3333,19L 44.3333,23.75L 39.5833,23.75L 39.5833,25.4115C 42.7678,25.7277 45.6747,26.9874 48.0205,28.907L 49.1629,27.7646L 46.9237,25.5254L 50.2825,22.1667L 57,28.8842L 53.6412,32.2429L 51.4021,30.0038L 50.2597,31.1462C 52.4933,33.8756 53.8333,37.3647 53.8333,41.1667 Z M 26.2296,39.5834L 30.0833,39.5834L 30.0833,42.75L 26.2296,42.75C 26.9347,48.0419 31.1248,52.232 36.4166,52.9371L 36.4166,49.0833L 39.5833,49.0833L 39.5833,52.937C 44.8752,52.232 49.0653,48.0419 49.7703,42.75L 45.9166,42.75L 45.9166,39.5834L 49.7703,39.5834C 49.0652,34.2915 44.8751,30.1014 39.5833,29.3964L 39.5833,33.25L 36.4166,33.25L 36.4166,29.3963C 31.1248,30.1014 26.9347,34.2915 26.2296,39.5834 Z M 38,38C 39.7489,38 41.1666,39.4178 41.1666,41.1667C 41.1666,42.9156 39.7489,44.3334 38,44.3334L 31.6666,49.0834L 34.8333,41.1667C 34.8333,39.4178 36.2511,38 38,38 Z ";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
