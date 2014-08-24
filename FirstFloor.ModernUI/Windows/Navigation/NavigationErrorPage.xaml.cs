namespace FirstFloor.ModernUI.Windows.Navigation
{
    /// <summary>
    /// Interaction logic for NavigationErrorPage.xaml
    /// </summary>
    public partial class NavigationErrorPage
    {
        public NavigationErrorPage(string unknownPageLink, string contentLoader)
        {
            InitializeComponent();
            TxtError.Text = string.Format("The page link:  {0}\n was not handled by {1}", unknownPageLink, contentLoader);
        }
    }
}
