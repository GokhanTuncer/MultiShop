using MultiShop.DTOLayer.OrderDTOs.OrderAddressDTOs;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
        Task CreateOrderAddressAsync(CreateOrderAddressDTO createOrderAddressDto);
    }
}
