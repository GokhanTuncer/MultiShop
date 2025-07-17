using MultiShop.Discount.DTOs;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDTO>> GetAllCouponAsync();
        Task CreateCouponAsync(CreateCouponDTO createCouponDTO);
        Task UpdateCouponAsync(UpdateCouponDTO updateCouponDTO);
        Task DeleteCouponAsync(int id);
        Task<GetByIDCouponDTO> GetByIDCouponAsync(int id);
        Task<ResultCouponDTO> GetCodeDetailByCode(string code);

        int GetDiscountCountRate(string code);
        Task<int> GetDiscountCount();
    }
}
