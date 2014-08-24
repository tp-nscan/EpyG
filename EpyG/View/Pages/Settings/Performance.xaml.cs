using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Settings;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Settings
{
    /// <summary>
    /// Interaction logic for Performance.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Settings/Performance.xaml")]
    public partial class Performance : IContent, IPartImportsSatisfiedNotification
    {
        public Performance()
        {
            InitializeComponent();
        }

        [Import]
        PerformanceVm PerformanceVm { get; set; }

        public void OnImportsSatisfied()
        {
            DataContext = PerformanceVm;
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
