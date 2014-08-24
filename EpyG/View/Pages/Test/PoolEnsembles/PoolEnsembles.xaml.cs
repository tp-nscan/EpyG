using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Test;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Test.PoolEnsembles
{
    /// <summary>
    /// Interaction logic for PoolEnsembles.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Test/PoolEnsembles/PoolEnsembles.xaml")]
    public partial class PoolEnsembles : IContent, IPartImportsSatisfiedNotification
    {
        public PoolEnsembles()
        {
            InitializeComponent();
        }

        [Import]
        PoolEnsemblesVm PoolEnsemblesVm { get; set; }

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
            DataContext = PoolEnsemblesVm;
        }
    }
}
