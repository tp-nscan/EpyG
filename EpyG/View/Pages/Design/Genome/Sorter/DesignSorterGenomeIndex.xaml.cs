using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Design;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Design.Genome.Sorter
{
    [ModernUiContent("/View/Pages/Design/Genome/Sorter/DesignSorterGenomeIndex.xaml")]
    public partial class DesignSorterGenomeIndex : IContent, IPartImportsSatisfiedNotification
    {
        public DesignSorterGenomeIndex()
        {
            InitializeComponent();
        }

        [Import]
        DesignSorterGenomeVm DesignSorterGenomeVm { get; set; }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            var s = "S";
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
            DataContext = DesignSorterGenomeVm;
        }
    }
}
