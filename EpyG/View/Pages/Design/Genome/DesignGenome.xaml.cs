using CommonUI;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using SorterControls.DesignVms.Sorter;

namespace EpyG.View.Pages.Design.Genome
{
    /// <summary>
    /// Interaction logic for Genomes.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Design/Genome/DesignGenome.xaml")]
    public partial class DesignGenome : IContent
    {
        public DesignGenome()
        {
            InitializeComponent();
            DataContext = new DesignSorterVm();
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
