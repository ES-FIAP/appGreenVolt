using greenVolt.Models;
using greenVolt.Services;

namespace greenVolt.Pages;

public partial class Enterprises : ContentPage
{

    private readonly ApiService _apiService;
    public Enterprises(ApiService apiService)
	{
		InitializeComponent();
        BindingContext = new MainViewModel(apiService);
    }
    
}