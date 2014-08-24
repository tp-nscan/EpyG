using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Design;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Design.RandomSampler
{
    /// <summary>
    /// Interaction logic for RandomSorters.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Design/RandomSampler/RandomSorters.xaml")]
    public partial class RandomSorters : IContent, IPartImportsSatisfiedNotification
    {
        public RandomSorters()
        {
            InitializeComponent();
        }

        [Import]
        RandomSortersVm RandomSortersVm { get; set; }
        public void OnImportsSatisfied()
        {
            DataContext = RandomSortersVm;
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
