using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Test.Sorter;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Test.Sorter
{
    [ModernUiContent("/View/Pages/Test/Sorter/TestSorter.xaml")]
    public partial class TestSorter : IContent, IPartImportsSatisfiedNotification
    {
        public TestSorter()
        {
            InitializeComponent();
        }

        [Import]
        private TestSorterVm TestSorterVm { get; set; }

        [Import]
        private TestSorterSpecVm TestSorterSpecVm { get; set; }

        public void OnImportsSatisfied()
        {
            DataContext = TestSorterVm;
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
