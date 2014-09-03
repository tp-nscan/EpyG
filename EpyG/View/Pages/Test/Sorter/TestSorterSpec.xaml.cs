using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Test.Sorter;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Test.Sorter
{
    [ModernUiContent("/View/Pages/Test/Sorter/TestSorterSpec.xaml")]
    public partial class TestSorterSpec : IContent, IPartImportsSatisfiedNotification
    {
        public TestSorterSpec()
        {
            InitializeComponent();
        }

        [Import]
        TestSorterSpecVm TestSorterSpecVm { get; set; }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            var s = "S";
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
            var s = "S";
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            var s = "S";
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            var s = "S";
        }

        public void OnImportsSatisfied()
        {
            DataContext = TestSorterSpecVm;
        }
    }
}
