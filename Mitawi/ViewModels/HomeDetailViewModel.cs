namespace Mitawi.ViewModels;

[QueryProperty(nameof(Days), nameof(Days))]
public partial class HomeDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    private Daily myDaily;

    [ObservableProperty]
    private List<Daily> days;

    partial void OnDaysChanged(List<Daily> value)
    {
        MyDaily = value.ElementAt(1);
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await Shell.Current.GoToAsync("..", true);
    }

}