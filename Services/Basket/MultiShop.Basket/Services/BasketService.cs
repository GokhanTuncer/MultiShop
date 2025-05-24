using MultiShop.Basket.DTOs;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisService.GetDB().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDTO> GetBasket(string userId)
        {
           var existBasket = await _redisService.GetDB().StringGetAsync(userId);
            return JsonSerializer.Deserialize<BasketTotalDTO>(existBasket);
                }

        public async Task SaveBasket(BasketTotalDTO basketTotalDTO)
        {
            await _redisService.GetDB().StringSetAsync(basketTotalDTO.UserID, JsonSerializer.Serialize(basketTotalDTO));
        }
    }
}
