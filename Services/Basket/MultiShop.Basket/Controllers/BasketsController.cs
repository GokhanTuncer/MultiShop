using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.DTOs;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }
        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var user = User.Claims;
            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDTO basketTotalDTO)
        {
            basketTotalDTO.UserID = _loginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDTO);
            return Ok("Sepetteki değişiklikler kaydedildi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMyBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Sepetiniz silindi.");
        }
    }
}
