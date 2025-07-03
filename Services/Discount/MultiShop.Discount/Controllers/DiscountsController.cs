using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.DTOs;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> CouponList()
        {
            var result = await _discountService.GetAllCouponAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponByID(int id)
        {
            var result = await _discountService.GetByIDCouponAsync(id);
            return Ok(result);
        }
        [HttpGet("GetCodeDetailByCodeAsync")]
        public async Task<IActionResult> GetCodeDetailByCodeAsync(string code)
        {
            var result = await _discountService.GetCodeDetailByCode(code);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDTO createCouponDTO)
        {
            await _discountService.CreateCouponAsync(createCouponDTO);
            return Ok("Kupon başarıyla oluşturuldu");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _discountService.DeleteCouponAsync(id);
            return Ok("Kupon başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDTO updateCouponDTO)
        {
            await _discountService.UpdateCouponAsync(updateCouponDTO);
            return Ok("Kupon başarıyla güncellendi");
        }
    }
}
