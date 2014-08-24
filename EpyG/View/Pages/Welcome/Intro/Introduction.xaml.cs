using System.ComponentModel.Composition;
using CommonUI;
using EpyG.ViewModel.Pages.Welcome;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;

namespace EpyG.View.Pages.Welcome.Intro
{
    /// <summary>
    /// Interaction logic for Introduction.xaml
    /// </summary>
    [ModernUiContent("/View/Pages/Welcome/Intro/Introduction.xaml")]
    public partial class Introduction : IContent, IPartImportsSatisfiedNotification
    {
        public Introduction()
        {
            InitializeComponent();
        }

        [Import]
        IntroductionVm IntroductionVm { get; set; }

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
            DataContext = IntroductionVm;
        }
    }
}
