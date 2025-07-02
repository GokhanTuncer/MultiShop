using MultiShop.DTOLayer.CatalogDTOs.ProductImageDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDTO>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDTO createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIDProductImageDTO> GetByIdProductImageAsync(string id);
        Task<GetByIDProductImageDTO> GetByProductIdProductImageAsync(string id);
    }
}
