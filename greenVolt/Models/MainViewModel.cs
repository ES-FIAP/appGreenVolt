using greenVolt.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace greenVolt.Models
{
    public class MainViewModel: BaseViewModel
    {
        private readonly ApiService _apiService;
        public ObservableCollection<Company> Companies { get; set; }
        public MainViewModel(ApiService apiService)
        {
            _apiService = apiService;

        }
private async void LoadCompanies()
        {
        {
            try
            {
                 IsBusy = true;
                var companies = await _apiService.GetEmpresasAsync();

                Companies.Clear();
                foreach (var company in companies)
                {
                    Companies.Add(company);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar empresas: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
    }
}
