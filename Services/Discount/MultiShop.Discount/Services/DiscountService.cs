using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.DTOs;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateCouponDTO createCouponDTO)
        {
            string query = "INSERT INTO Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDTO.Code);
            parameters.Add("@rate", createCouponDTO.Rate);
            parameters.Add("@isActive", createCouponDTO.IsActive);
            parameters.Add("@validDate", createCouponDTO.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "DELETE FROM Coupons WHERE CouponID = @couponID";
            var parameters = new DynamicParameters();
            parameters.Add("@couponID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCouponDTO>> GetAllCouponAsync()
        {
            string query = "SELECT * FROM Coupons";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<ResultCouponDTO>(query);
                return result.ToList();
            }
        }

        public async Task<GetByIDCouponDTO> GetByIDCouponAsync(int id)
        {
            string query = "SELECT * FROM Coupons WHERE CouponID = @couponID";
            var parameters = new DynamicParameters();
            parameters.Add("@couponID", id);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<GetByIDCouponDTO>(query, parameters);
                return result;
            }
        }

        public async Task<ResultCouponDTO> GetCodeDetailByCode(string code)
        {
            string query = "SELECT * FROM Coupons WHERE Code = @code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<ResultCouponDTO>(query, parameters);
                return result;
            }
        }

        public int GetDiscountCountRate(string code)
        {
            string query = "Select Rate From Coupons Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDTO updateCouponDTO)
        {
            string query = "UPDATE Coupons SET Code = @code, Rate = @rate, IsActive = @isActive, ValidDate = @validDate WHERE CouponID = @couponID";
            var parameters = new DynamicParameters();
            parameters.Add("@couponID", updateCouponDTO.CouponID);
            parameters.Add("@code", updateCouponDTO.Code);
            parameters.Add("@rate", updateCouponDTO.Rate);
            parameters.Add("@isActive", updateCouponDTO.IsActive);
            parameters.Add("@validDate", updateCouponDTO.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
