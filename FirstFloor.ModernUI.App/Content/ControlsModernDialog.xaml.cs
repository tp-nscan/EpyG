using FirstFloor.ModernUI.Windows.Controls;
using System.Windows;

namespace FirstFloor.ModernUI.App.Content
{
    /// <summary>
    /// Interaction logic for ControlsModernDialog.xaml
    /// </summary>
    public partial class ControlsModernDialog
    {
        public ControlsModernDialog()
        {
            InitializeComponent();
        }

        private void CommonDialog_Click(object sender, RoutedEventArgs e)
        {
            new ModernDialog {
                Title = "Common dialog",
                Content = new LoremIpsum()
            }.ShowDialog();
        }

        private void MessageDialog_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxButton btn = MessageBoxButton.OK;
            if (true == ok.IsChecked) btn = MessageBoxButton.OK;
            else if (true == okcancel.IsChecked) btn = MessageBoxButton.OKCancel;
            else if (true == yesno.IsChecked) btn = MessageBoxButton.YesNo;
            else if (true == yesnocancel.IsChecked) btn = MessageBoxButton.YesNoCancel;

            var result = ModernDialog.ShowMessage("This is a simple Modern UI styled message dialog. Do you like it?", "Message Dialog", btn);

            this.runResult.Text = result.ToString();
        }
    }
}
