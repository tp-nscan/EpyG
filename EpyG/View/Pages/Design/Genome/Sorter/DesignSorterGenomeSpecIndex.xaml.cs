using System;
using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Design.Genome;
using EpyG.ViewModel.Pages.Design.Genome.Sorter;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using SorterControls.DesignVms.Genome;
using SorterControls.ViewModel.Genome;

namespace EpyG.View.Pages.Design.Genome.Sorter
{
    [ModernUiContent("/View/Pages/Design/Genome/Sorter/DesignSorterGenomeSpecIndex.xaml")]
    public partial class DesignSorterGenomeSpecIndex : IContent, IPartImportsSatisfiedNotification
    {
        public DesignSorterGenomeSpecIndex()
        {
            InitializeComponent();
        }

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

        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {

            var s = "S";
        }

        public void OnImportsSatisfied()
        {
            DataContext = DesignSorterGenomeSpecIndexVm;
        }

    }
}
