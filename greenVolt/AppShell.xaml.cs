namespace greenVolt
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            var navPage = new NavigationPage(new MainPage());


        }
    }
}
