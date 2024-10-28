using rootear.mvvm.Models;
using System.Globalization;

namespace rootear.Utils
{
    public class IntToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is string Value && Value == "Administrador";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class LugarDisplayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Lugar lugar)
            {
                // Mostrar Ciudad, Provincia y CodPostal en el Picker
                return $"{lugar.Ciudad}, {lugar.Provincia}, {lugar.CodPostal}";
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
