using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Design;
using EpyG.ViewModel.Pages.Design.Genome.Sorter;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

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
