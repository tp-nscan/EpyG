using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Gallery;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Gallery.GalleryCompPools
{
    /// <summary>
    /// Interaction logic for CompPools.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Gallery/GalleryCompPools/GalleryCompPools.xaml")]
    public partial class GalleryCompPools : IContent, IPartImportsSatisfiedNotification
    {
        public GalleryCompPools()
        {
            InitializeComponent();
        }

        [Import]
        GalleryCompPoolsVm GalleryCompPoolsVm { get; set; }

        public void OnImportsSatisfied()
        {
            DataContext = GalleryCompPoolsVm;
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
