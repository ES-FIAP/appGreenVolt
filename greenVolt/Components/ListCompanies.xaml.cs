using greenVolt.Models;
using System.Collections.ObjectModel;

namespace greenVolt.Components
{
    public partial class ListCompanies : ContentView
    {
        public static readonly BindableProperty CompaniesProperty =
            BindableProperty.Create(nameof(Companies), typeof(ObservableCollection<Company>), typeof(ListCompanies), null);

        public ObservableCollection<Company> Companies
        {
            get => (ObservableCollection<Company>)GetValue(CompaniesProperty);  // Usando BindableObject.GetValue
            set => SetValue(CompaniesProperty, value);  // Usando BindableObject.SetValue
        }

        public ListCompanies()
        {
            InitializeComponent();
        }
    }
}
