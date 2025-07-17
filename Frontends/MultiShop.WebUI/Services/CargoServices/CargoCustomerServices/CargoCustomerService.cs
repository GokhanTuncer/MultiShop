using MultiShop.DTOLayer.CargoDTOs.CargoCustomerDTOs;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;
        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GetCargoCustomerByIDDTO> GetByIdCargoCustomerInfoAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("CargoCustomers/GetCargoCustomerByID?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetCargoCustomerByIDDTO>();
            return values;
        }
    }
}
