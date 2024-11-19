namespace greenVolt.Components;

public partial class CompanyCard : ContentView
{
	public CompanyCard()
	{
		InitializeComponent();
	}

    public static readonly BindableProperty DataProperty =
          BindableProperty.Create(nameof(Data), typeof(CompanyCard), typeof(CompanyCard));

    public CompanyCard Data
    {
        get => (CompanyCard)GetValue(DataProperty);
        set => SetValue(DataProperty, value);
    }
}