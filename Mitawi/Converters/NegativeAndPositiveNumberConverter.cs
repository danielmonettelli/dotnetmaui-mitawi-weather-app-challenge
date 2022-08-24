using CommunityToolkit.Maui.Converters;
using System.Globalization;

namespace Mitawi.Converters
{
    public class NegativeAndPositiveNumberConverter : BaseConverter<object, object>
    {
        public override object ConvertFrom(object value, CultureInfo culture)
        {
            int number = (int)value;

            return number < 0 ? number : "+" + number;
        }

        public override object ConvertBackTo(object value, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
