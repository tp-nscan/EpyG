using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Design;
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

        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {

        }

        public void OnImportsSatisfied()
        {
            DataContext = DesignSorterGenomeTypeVm;
        }
    }
}
