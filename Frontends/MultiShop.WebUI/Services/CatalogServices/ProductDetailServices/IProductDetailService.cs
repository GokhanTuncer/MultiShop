using MultiShop.DTOLayer.CatalogDTOs.ProductDetailDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService 
    {
        Task<List<ResultProductDetailDTO>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIDProductDetailDTO> GetByIdProductDetailAsync(string id);
        Task<GetByIDProductDetailDTO> GetByProductIdProductDetailAsync(string id);
    }
}
