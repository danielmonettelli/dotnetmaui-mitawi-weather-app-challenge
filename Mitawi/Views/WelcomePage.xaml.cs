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

        RunWelcomeAnimation();
    }

    private void RunWelcomeAnimation()
    {
        btnGetStarted.IsEnabled = false;

        lblPhrase1.IsVisible = true;
        lblPhrase2.IsVisible = true;
        imgWeather.IsVisible = true;
        lblPhrase3.IsVisible = true;
        lblPhrase4.IsVisible = true;
        btnGetStarted.IsVisible = true;

        lblPhrase1.Opacity = 0;
        lblPhrase2.Opacity = 0;
        imgWeather.Opacity = 0;
        lblPhrase3.Opacity = 0;
        lblPhrase4.Opacity = 0;
        btnGetStarted.Opacity = 0;

        new Animation
        {
            { 0, 0.2, new Animation(v => lblPhrase1.Opacity = v, 0, 1, Easing.CubicInOut) },
            { 0.1, 0.3, new Animation(v => lblPhrase2.Opacity = v, 0, 1, Easing.CubicInOut) },
            { 0.3, 0.5, new Animation(v => imgWeather.Opacity = v, 0, 1, Easing.CubicInOut) },
            { 0.3, 0.5, new Animation(v => imgWeather.Scale = v, 0, 1, Easing.SpringOut) },
            { 0.5, 0.7, new Animation(v => lblPhrase3.Opacity = v, 0, 1, Easing.CubicInOut) },
            { 0.6, 0.8, new Animation(v => lblPhrase4.Opacity = v, 0, 1, Easing.CubicInOut) },
            { 0.8, 1, new Animation(v =>
              {
                  btnGetStarted.Opacity = v;
                  btnGetStarted.Scale = v;
              },0,1,Easing.BounceOut,finished: ()=>
              {
                  btnGetStarted.IsEnabled = true;
              })
            }
        }.Commit(owner: this, name: "WelcomeAnimation", length: 3500);
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