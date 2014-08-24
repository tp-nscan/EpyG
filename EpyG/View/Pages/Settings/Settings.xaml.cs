using CommonUI;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Settings
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Settings/Settings.xaml")]
    public partial class Settings : IContent
    {
        public Settings()
        {
            InitializeComponent();
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
        }
    }
}
