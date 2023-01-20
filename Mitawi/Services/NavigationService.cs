namespace Mitawi.Services
{
    public class NavigationService : INavigationService
    {
        private Dictionary<string, Type> pages { get; } = new Dictionary<string, Type>();

        public Page MainPage => Application.Current.MainPage;

        public void Configure(string key, Type pageType)
        {
            pages[key] = pageType;
        }

        public void GoBack()
        {
            MainPage.Navigation.PopAsync();
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            if (pages.TryGetValue(pageKey, out Type pageType))
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                page.SetNavigationArgs(parameter);

                MainPage.Navigation.PushAsync(page);

                (page.BindingContext as BaseViewModel).Initialize(parameter);
            }
            else
            {
                throw new ArgumentException($"This page doesn't exist: {pageKey}.", nameof(pageKey));
            }
        }
    }

    public static class NavigationExtensions
    {
        private static readonly ConditionalWeakTable<Page, object> arguments = new ConditionalWeakTable<Page, object>();

        public static object GetNavigationArgs(this Page page)
        {
            arguments.TryGetValue(page, out object argument);

            return argument;
        }

        public static void SetNavigationArgs(this Page page, object args)
        {
            arguments.Add(page, args);
        }
    }
}
