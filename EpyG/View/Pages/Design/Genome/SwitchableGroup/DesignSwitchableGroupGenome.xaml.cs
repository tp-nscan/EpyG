using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Design;
using EpyG.ViewModel.Pages.Design.Genome.SwitchableGroup;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Design.Genome.SwitchableGroup
{
    /// <summary>
    /// Interaction logic for SwitchableGenome.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Design/Genome/SwitchableGroup/DesignSwitchableGroupGenome.xaml")]
    public partial class DesignSwitchableGroupGenome : IContent, IPartImportsSatisfiedNotification
    {
        public DesignSwitchableGroupGenome()
        {
            InitializeComponent();
        }

        [Import]
        DesignSwitchableGroupGenomeVm DesignSwitchableGroupGenomeVm { get; set; }

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
            DataContext = DesignSwitchableGroupGenomeVm;
        }
    }
}
