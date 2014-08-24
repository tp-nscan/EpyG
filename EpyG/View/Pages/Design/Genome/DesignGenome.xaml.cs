using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Design;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Design.Genome
{
    /// <summary>
    /// Interaction logic for Genomes.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Design/Genome/DesignGenome.xaml")]
    public partial class DesignGenome : IContent, IPartImportsSatisfiedNotification
    {
        public DesignGenome()
        {
            InitializeComponent();
        }

        [Import]
        DesignGenomeVm DesignGenomeVm { get; set; }

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
            DataContext = DesignGenomeVm;
        }
    }
}
