using CommonUI;
using EpyG.ViewModel.Pages.Design.Genome;
using EpyG.ViewModel.Pages.Design.Genome.Sorter;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Design.Genome.Sorter
{
    /// <summary>
    /// Interaction logic for DesignSorterGenomeSpecPermutation.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Design/Genome/Sorter/DesignSorterGenomeSpecPermutation.xaml")]
    public partial class DesignSorterGenomeSpecPermutation : IContent
    {
        public DesignSorterGenomeSpecPermutation()
        {
            InitializeComponent();

            DataContext = new DesignSorterGenomeSpecPermutationVm();
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
