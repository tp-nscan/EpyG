using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel;
using EpyG.ViewModel.Pages.Settings;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Settings
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Settings/Appearance.xaml")]
    public partial class Appearance : IContent, IPartImportsSatisfiedNotification
    {
        public Appearance()
        {
            InitializeComponent();
        }

        [Import]
        private AppearanceVm AppearanceVm { get; set; }

        public void OnImportsSatisfied()
        {
            DataContext = AppearanceVm;
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
