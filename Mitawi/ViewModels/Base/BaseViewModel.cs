namespace Mitawi.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        public virtual void Initialize(object parameter)
        {

        }

        [ObservableProperty]
        private bool isBusy = false;
    }
}
