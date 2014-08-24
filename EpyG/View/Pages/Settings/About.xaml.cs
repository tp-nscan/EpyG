using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Settings;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Settings
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Settings/About.xaml")]
    public partial class About : IContent, IPartImportsSatisfiedNotification
    {
        public About()
        {
            InitializeComponent();
        }

        [Import]
        AboutVm AboutVm { get; set; }

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

        public void OnImportsSatisfied()
        {
            DataContext = AboutVm;
        }
    }
}
