namespace Mitawi.Converters;

public class CustomImageUrlScalingConverter : BaseConverter<object, object, object>
{
    public override object DefaultConvertReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public override object DefaultConvertBackReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override object ConvertFrom(object value, object parameter, CultureInfo culture)
    {
        // Image scale type in the parameter: 2(100x100approx), 4(200x200approx), 10(500x500approx)
        return "https://raw.githubusercontent.com/danielmonettelli/MyResources/main/OpenWeather_Icons_Redesign/" + value + "@" + parameter + "x.png";
    }

    public override object ConvertBackTo(object value, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
