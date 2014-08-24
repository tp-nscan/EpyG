using System.ComponentModel.Composition;
using CommonUI;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Design.RandomSearch
{
    /// <summary>
    /// Interaction logic for RandomSorterGenomesByMutation.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Design/RandomSearch/RandomSorterGenomesByMutation.xaml")]
    public partial class RandomSorterGenomesByMutation : IContent, IPartImportsSatisfiedNotification
    {
        public RandomSorterGenomesByMutation()
        {
            InitializeComponent();
        }

        public void OnImportsSatisfied()
        {
            DataContext = null;
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
