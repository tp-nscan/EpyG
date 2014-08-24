using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Gallery;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Gallery.HOF
{
    /// <summary>
    /// Interaction logic for Hof.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Gallery/HOF/Hof.xaml")]
    public partial class Hof : IContent, IPartImportsSatisfiedNotification
    {
        public Hof()
        {
            InitializeComponent();
        }

        [Import]
        HoflVm HoflVm { get; set; }

        public void OnImportsSatisfied()
        {
            DataContext = HoflVm;
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
