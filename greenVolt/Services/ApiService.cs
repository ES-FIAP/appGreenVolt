using AutoMapper;
using greenVolt.Models;
using greenVolt.Dominio;
using System.Text.Json;
using System.Text;

namespace greenVolt.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public ApiService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<List<Company>> GetEmpresasAsync()
        {
            var response = await _httpClient.GetAsync("/api/empresas");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var empresasApi = JsonSerializer.Deserialize<List<Empresa>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });


            return _mapper.Map<List<Company>>(empresasApi);
        }

        public async Task<Company> CreateEmpresaAsync(Company newEnterprise)
        {
            var empresaApi = _mapper.Map<Empresa>(newEnterprise);

            var content = new StringContent(JsonSerializer.Serialize(empresaApi), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/empresas", content);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var createdEmpresa = JsonSerializer.Deserialize<Empresa>(json);
            return _mapper.Map<Company>(createdEmpresa);
        }
    }
}
