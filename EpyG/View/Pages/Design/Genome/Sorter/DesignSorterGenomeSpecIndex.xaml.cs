using CommonUI;
using EpyG.ViewModel.Pages.Design.Genome;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Design.Genome.Sorter
{
    [ModernUiContent("/View/Pages/Design/Genome/Sorter/DesignSorterGenomeSpecIndex.xaml")]
    public partial class DesignSorterGenomeSpecIndex : IContent
    {
        public DesignSorterGenomeSpecIndex()
        {
            InitializeComponent();

            DataContext = new DesignSorterGenomeSpecIndexVm();
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
