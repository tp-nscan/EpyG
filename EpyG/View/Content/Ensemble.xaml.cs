using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel;
using EpyG.ViewModel.Content;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Content
{
    /// <summary>
    /// Interaction logic for Ensemble.xaml
    /// </summary>
    [ModernUiContent("/Pages/Ensemble.xaml")]
    public partial class Ensemble : IContent, IPartImportsSatisfiedNotification
    {
        public Ensemble()
        {
            InitializeComponent();
        }

        [Import]
        EnsembleVm EnsembleVm { get; set; }
        public void OnImportsSatisfied()
        {
            DataContext = EnsembleVm;
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
