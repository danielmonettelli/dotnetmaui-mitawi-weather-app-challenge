namespace Mitawi.Converters;

public class UnixTimeToDateTimeConverter : BaseConverter<object, object, object>
{
    public override object DefaultConvertReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public override object DefaultConvertBackReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override object ConvertFrom(object value, object parameter, CultureInfo culture)
    {
        DateTimeOffset dateTimeOffSet = DateTimeOffset.FromUnixTimeSeconds((long)value).ToLocalTime();
        DateTime dateTime = dateTimeOffSet.DateTime;
        return dateTime.ToString((string)parameter);
    }

    public override object ConvertBackTo(object value, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
