using greenVolt.Models;

namespace greenVolt.Pages;

public partial class Enterprises : ContentPage
{
	public Enterprises()
	{
		InitializeComponent();
        BindingContext = new MainViewModel();
    }
}