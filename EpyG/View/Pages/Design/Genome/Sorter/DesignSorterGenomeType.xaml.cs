using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Design;
using EpyG.ViewModel.Pages.Design.Genome.Sorter;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Design.Genome.Sorter
{
    [ModernUiContent("/View/Pages/Design/Genome/Sorter/DesignSorterGenomeType.xaml")]
    public partial class DesignSorterGenomeType : IContent, IPartImportsSatisfiedNotification
    {
        public DesignSorterGenomeType()
        {
            InitializeComponent();
        }

        [Import]
        DesignSorterGenomeTypeVm DesignSorterGenomeTypeVm { get; set; }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {

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
            DataContext = DesignSorterGenomeTypeVm;
        }
    }
}
