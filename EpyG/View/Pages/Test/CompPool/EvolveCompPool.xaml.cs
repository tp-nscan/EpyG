using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Test;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Test.CompPool
{
    /// <summary>
    /// Interaction logic for SinglePool.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Test/CompPool/EvolveCompPool.xaml")]
    public partial class EvolveCompPool : IContent, IPartImportsSatisfiedNotification
    {
        public EvolveCompPool()
        {
            InitializeComponent();
        }

        [Import]
        EvolveCompPoolVm EvolveCompPoolVm { get; set; }

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
            DataContext = EvolveCompPoolVm;
        }
    }
}
