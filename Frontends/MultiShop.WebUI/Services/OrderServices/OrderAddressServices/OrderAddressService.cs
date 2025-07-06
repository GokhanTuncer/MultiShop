using MultiShop.DTOLayer.OrderDTOs.OrderAddressDTOs;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public class OrderAddressService : IOrderAddressService
    {
        private readonly HttpClient _httpClient;
        public OrderAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateOrderAddressAsync(CreateOrderAddressDTO createOrderAddressDto)
        { 
            await _httpClient.PostAsJsonAsync<CreateOrderAddressDTO>("addresses", createOrderAddressDto);
        }
    }
}
