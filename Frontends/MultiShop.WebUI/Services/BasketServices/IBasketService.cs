using MultiShop.DTOLayer.BasketDTOs;

namespace MultiShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDTO> GetBasket();
        Task SaveBasket(BasketTotalDTO basketTotalDto);
        Task DeleteBasket(string userId);
        Task AddBasketItem(BasketItemDTO basketItemDto);
        Task<bool> RemoveBasketItem(string productId);
    }
}
