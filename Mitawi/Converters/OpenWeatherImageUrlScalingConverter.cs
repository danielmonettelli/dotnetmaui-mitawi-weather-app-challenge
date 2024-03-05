namespace Mitawi.Converters;

public class OpenWeatherImageUrlScalingConverter : BaseConverter<object, object, object>
{
    public override object DefaultConvertReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public override object DefaultConvertBackReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override object ConvertFrom(object value, object parameter, CultureInfo culture)
    {
        // Image scale type in the parameter: 2(100x100), 4(200x200)
        return "http://openweathermap.org/img/wn/" + value + "@" + parameter + "x.png";
    }

    public override object ConvertBackTo(object value, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
