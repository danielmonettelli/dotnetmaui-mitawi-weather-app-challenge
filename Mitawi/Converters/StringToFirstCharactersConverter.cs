using CommunityToolkit.Maui.Converters;
using System.Globalization;

namespace Mitawi.Converters
{
    public class StringToFirstCharactersConverter : ICommunityToolkitValueConverter
    {
        public Type FromType => throw new NotImplementedException();

        public Type ToType => throw new NotImplementedException();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().Substring(0, System.Convert.ToInt32(parameter));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
