namespace Mitawi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            SizeChanged += HomePage_Orientation;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await CheckAndRequestLocationPermission();

            BindingContext = ViewModelLocator.HomeViewModel;
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

        private void HomePage_Orientation(object sender, EventArgs e)
        {
            string visualStateOrientation = Height > Width ? "Portrait" : "Landscape";

            VisualStateManager.GoToState(gridParent, visualStateOrientation);
            VisualStateManager.GoToState(topLayerLower1, visualStateOrientation);
            VisualStateManager.GoToState(topLayerHigher2, visualStateOrientation);
            VisualStateManager.GoToState(gridAdminTopLayerHigher2, visualStateOrientation);
            VisualStateManager.GoToState(iconAndTextLocation, visualStateOrientation);
            VisualStateManager.GoToState(iconPicker, visualStateOrientation);
            VisualStateManager.GoToState(updating, visualStateOrientation);
            VisualStateManager.GoToState(lookTemperature, visualStateOrientation);
            VisualStateManager.GoToState(lookWeatherAndDt, visualStateOrientation);
            VisualStateManager.GoToState(dividingLine, visualStateOrientation);
            VisualStateManager.GoToState(gridComplexDescriptionClimate, visualStateOrientation);
            VisualStateManager.GoToState(stackTodayAnd7Days, visualStateOrientation);
            VisualStateManager.GoToState(scrollForecast24Hours, visualStateOrientation);
            VisualStateManager.GoToState(flexLayoutForecast24Hours, visualStateOrientation);
        }

        private void SelectedWeather_Tapped(object sender, EventArgs e)
        {
            VisualElement surfaceWeather = sender as VisualElement;
            FlexLayout parent = surfaceWeather.Parent as FlexLayout;

            foreach (View child in parent.Children.Cast<View>())
            {
                VisualStateManager.GoToState(child, "Normal");
                ChangeSurfaceControls(child, false);
            }
            VisualStateManager.GoToState(surfaceWeather, "Selected");
            ChangeSurfaceControls(surfaceWeather, true);
        }

        private static void ChangeSurfaceControls(VisualElement child, bool isSelected)
        {
            Label labelTemperature = child.FindByName<Label>("labelTemperature");
            Image imageSmallWeather = child.FindByName<Image>("imageSmallWeather");
            Label labelHour = child.FindByName<Label>("labelHour");

            string visualStateControl = isSelected ? "Selected" : "Normal";
            VisualStateManager.GoToState(labelTemperature, visualStateControl);
            VisualStateManager.GoToState(imageSmallWeather, visualStateControl);
            VisualStateManager.GoToState(labelHour, visualStateControl);
        }

    }
}