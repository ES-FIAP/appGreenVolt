using greenVolt.Pages;

namespace greenVolt
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

        private async void CreateAccountButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }
    }

}
