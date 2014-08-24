using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Home.xaml")]
    public partial class Home : IContent, IPartImportsSatisfiedNotification
    {
        public Home()
        {
            InitializeComponent();
        }

        [Import]
        private HomeVm HomeVM { get; set; }

        public void OnImportsSatisfied()
        {
            this.DataContext = this.HomeVM;
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
