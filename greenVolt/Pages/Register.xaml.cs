namespace greenVolt.Pages;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}

    private async void Button_ClickedHaveAccount(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login());
    }
}