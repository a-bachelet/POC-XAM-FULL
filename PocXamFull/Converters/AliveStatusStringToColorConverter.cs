using System;
using System.Globalization;
using Xamarin.Forms;

namespace PocXamFull.Converters
{
    public class AliveStatusStringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case "Alive":
                    return SolidColorBrush.LightGreen;
                case "Dead":
                    return SolidColorBrush.Red;
                default:
                    return SolidColorBrush.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Equals(SolidColorBrush.LightGreen))
            {
                return "Alive";
            } 
            else if (value.Equals(SolidColorBrush.Red))
            {
                return "Dead";
            }
            else
            {
                return "unknown";
            }
        }
    }
}
