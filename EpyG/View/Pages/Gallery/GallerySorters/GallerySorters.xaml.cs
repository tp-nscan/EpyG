using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Gallery;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Gallery.GallerySorters
{
    /// <summary>
    /// Interaction logic for Sorters.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Gallery/GallerySorters/GallerySorters.xaml")]
    public partial class GallerySorters : IContent, IPartImportsSatisfiedNotification
    {
        public GallerySorters()
        {
            InitializeComponent();
        }

        [Import]
        GallerySortersVm SortersVm { get; set; }

        public void OnImportsSatisfied()
        {

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
            DataContext = SortersVm;
        }
    }
}
