using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel;
using EpyG.ViewModel.Content;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Content
{
    /// <summary>
    /// Interaction logic for EnsembleParams.xaml
    /// </summary>
    [ModernUiContent("/Pages/EnsembleParams.xaml")]
    public partial class EnsembleParams : IContent, IPartImportsSatisfiedNotification
    {
        public EnsembleParams()
        {
            InitializeComponent();
        }

        [Import]
        EnsembleParamsVm EnsembleParamsVm { get; set; }
        public void OnImportsSatisfied()
        {
            DataContext = EnsembleParamsVm;
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
