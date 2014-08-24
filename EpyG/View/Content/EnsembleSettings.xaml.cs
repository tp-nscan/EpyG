using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel;
using EpyG.ViewModel.Content;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Content
{
    /// <summary>
    /// Interaction logic for EnsembleSettings.xaml
    /// </summary>
    [ModernUiContent("/Pages/EnsembleSettings.xaml")]
    public partial class EnsembleSettings : IContent, IPartImportsSatisfiedNotification
    {
        public EnsembleSettings()
        {
            InitializeComponent();
        }

        [Import]
        EnsembleSettingsVm EnsembleSettingsVm { get; set; }

        public void OnImportsSatisfied()
        {
            DataContext = EnsembleSettingsVm;
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