using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Design.Genome.Sorter;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Design.Genome.Sorter
{
    [ModernUiContent("/View/Pages/Design/Genome/Sorter/DesignSorterGenomeSpec.xaml")]
    public partial class DesignSorterGenomeSpec : IContent, IPartImportsSatisfiedNotification
    {
        public DesignSorterGenomeSpec()
        {
            InitializeComponent();
        }

        [Import]
        DesignSorterGenomeSpecVm DesignSorterGenomeSpecVm { get; set; }

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
            DataContext = DesignSorterGenomeSpecVm;
        }
    }
}
