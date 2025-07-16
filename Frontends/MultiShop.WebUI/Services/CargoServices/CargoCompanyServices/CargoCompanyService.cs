using MultiShop.DTOLayer.CargoDTOs.CargoCompanyDTOs;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;
        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDTO createCargoCompanyDTO)
        {
            await _httpClient.PostAsJsonAsync<CreateCargoCompanyDTO>("CargoCompanies", createCargoCompanyDTO);
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync("CargoCompanies?id=" + id);
        }

        public async Task<List<ResultCargoCompanyDTO>> GetAllCargoCompanyAsync()
        {
            var responseMessage = await _httpClient.GetAsync("CargoCompanies");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCargoCompanyDTO>>(jsonData);
            return values;
        }

        public async Task<UpdateCargoCompanyDTO> GetByIdCargoCompanyAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("CargoCompanies/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCargoCompanyDTO>();
            return values;
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDTO updateCargoCompanyDTO)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDTO>("CargoCompanies", updateCargoCompanyDTO);
        }
    }
}
