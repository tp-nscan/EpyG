using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Design;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Design.CompPool
{
    /// <summary>
    /// Interaction logic for Sorters.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Design/CompPool/DesignCompPool.xaml")]
    public partial class DesignCompPool : IContent, IPartImportsSatisfiedNotification
    {
        public DesignCompPool()
        {
            InitializeComponent();
        }

        [Import]
        DesignCompPoolVm DesignCompPoolVm { get; set; }

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
            DataContext = DesignCompPoolVm;
        }
    }
}
