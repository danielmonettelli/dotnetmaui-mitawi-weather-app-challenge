namespace Mitawi.Views;

public partial class WelcomePage : ContentPage
{
    readonly WelcomeViewModel vm = new();

    public WelcomePage()
    {
        InitializeComponent();

        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await CheckAndRequestLocationPermission();
    }

    private static async Task<PermissionStatus> CheckAndRequestLocationPermission()
    {
        PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

        if (status == PermissionStatus.Granted)
            return status;

        if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
        {
            // Prompt the user to turn on in settings
            // On iOS once a permission has been denied it may not be requested again from the application
            return status;
        }

        if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
        {
            // Prompt the user with additional information as to why the permission is needed
        }

        status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

        return status;
    }

}