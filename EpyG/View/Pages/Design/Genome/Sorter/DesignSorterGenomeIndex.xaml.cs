using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Design.Genome.Sorter;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using SorterControls.ViewModel.Genome;

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
        DesignSorterGenomeIndexVm DesignSorterGenomeIndexVm { get; set; }

        [Import]
        public DesignSorterGenomeSpecIndexVm DesignSorterGenomeSpecIndexVm { get; set; }

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
            DesignSorterGenomeIndexVm.GenomeEditorVm 
                = new GenomeEditorSwitchIndexVm(
                    keyCount: DesignSorterGenomeSpecIndexVm.SuggestedKeyParam.KeyCount, 
                    keyPairs: DesignSorterGenomeSpecIndexVm.KeyPairs);
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            var s = "S";

        }

        public void OnImportsSatisfied()
        {
            DataContext = DesignSorterGenomeIndexVm;
        }
    }
}
