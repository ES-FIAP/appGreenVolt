namespace greenVolt.Pages;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked_havent_account(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Register());
    }

    private async void Button_Clicked_login(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///Enterprises");

    }
}