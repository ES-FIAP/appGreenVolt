﻿namespace greenVolt.Pages
{
    public partial class MainPage : ContentPage
    {
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
