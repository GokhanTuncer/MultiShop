using MultiShop.DTOLayer.OrderDTOs.OrderOrderingDTOs;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIDDTO>> GetOrderingByUserID(string id);
    }
}
