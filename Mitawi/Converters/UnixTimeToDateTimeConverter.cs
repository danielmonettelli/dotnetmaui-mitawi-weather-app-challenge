using CommunityToolkit.Maui.Converters;
using System.Globalization;

namespace Mitawi.Converters
{
    public class UnixTimeToDateTimeConverter : ICommunityToolkitValueConverter
    {
        public Type FromType => throw new NotImplementedException();

        public Type ToType => throw new NotImplementedException();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTimeOffset dateTimeOffSet = DateTimeOffset.FromUnixTimeSeconds((long)value).ToLocalTime();
            DateTime dateTime = dateTimeOffSet.DateTime;
            return dateTime.ToString((string)parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
