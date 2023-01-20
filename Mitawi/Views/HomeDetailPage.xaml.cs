namespace Mitawi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeDetailPage : ContentPage
    {

        public HomeDetailPage()
        {
            InitializeComponent();

            SizeChanged += HomeDetailPage_Orientation;

            BindingContext = ViewModelLocator.HomeDetailViewModel;
        }

        private void HomeDetailPage_Orientation(object sender, System.EventArgs e)
        {
            string visualStateOrientation = Height > Width ? "Portrait" : "Landscape";

            VisualStateManager.GoToState(gridParent, visualStateOrientation);
            VisualStateManager.GoToState(topLayerLower1, visualStateOrientation);
            VisualStateManager.GoToState(topLayerHigher2, visualStateOrientation);
            VisualStateManager.GoToState(imageTomorrowWeather, visualStateOrientation);
            VisualStateManager.GoToState(scrollWeeklyWeather, visualStateOrientation);
        }

    }
}