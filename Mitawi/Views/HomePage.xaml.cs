using Mitawi.Utility;

namespace Mitawi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            SizeChanged += HomePage_Orientation;

            BindingContext = ViewModelLocator.HomeViewModel;
        }

        private void HomePage_Orientation(object sender, System.EventArgs e)
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
        }

        private void SelectedWeather_Tapped(object sender, System.EventArgs e)
        {
            VisualElement surfaceWeather = sender as VisualElement;
            FlexLayout parent = surfaceWeather.Parent as FlexLayout;

            foreach (View child in parent.Children)
            {
                VisualStateManager.GoToState(child, "Normal");
                ChangeSurfaceControls(child, false);
            }
            VisualStateManager.GoToState(surfaceWeather, "Selected");
            ChangeSurfaceControls(surfaceWeather, true);
        }

        private void ChangeSurfaceControls(VisualElement child, bool isSelected)
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