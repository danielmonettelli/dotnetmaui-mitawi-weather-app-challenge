namespace Mitawi.ViewModels;

public partial class WelcomeViewModel : BaseViewModel
{
    [RelayCommand]
    private async Task NextPage()
    {
        await Shell.Current.GoToAsync(
            state: nameof(HomePage),
            animate: true);
    }
}
