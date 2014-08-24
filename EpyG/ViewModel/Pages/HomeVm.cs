using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using CommonUI;
using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;

namespace EpyG.ViewModel.Pages
{
    [Export]
    public class HomeVm
    {
        public HomeVm()
        {
            // The MVVM police will arrest you for this: dialogs shouldn't be initiated from within a viewmodel. Demo purposes only
            this.HelloWorldCommand = new RelayCommand(o => ModernDialog.ShowMessage("Hello world!", "Hello world", MessageBoxButton.OK));
        }

        // export the command so it's accessible to the entire application
        [Command("cmd://home/helloworld")]
        public ICommand HelloWorldCommand { get; private set; }
    }
}
