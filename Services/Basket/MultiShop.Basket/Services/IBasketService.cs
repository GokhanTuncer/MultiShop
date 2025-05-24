using MultiShop.Basket.DTOs;

namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDTO> GetBasket(string userId);
        Task SaveBasket(BasketTotalDTO basketTotalDTO);
        Task DeleteBasket(string userId);
    }
}
