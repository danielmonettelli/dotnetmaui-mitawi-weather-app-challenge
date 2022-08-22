using CommunityToolkit.Maui.Converters;
using System.Globalization;

namespace Mitawi.Converters
{
    public class NegativeAndPositiveNumberConverter : ICommunityToolkitValueConverter
    {
        public Type FromType => throw new NotImplementedException();

        public Type ToType => throw new NotImplementedException();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number = (int)value;

            return number < 0 ? number : "+" + number;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
