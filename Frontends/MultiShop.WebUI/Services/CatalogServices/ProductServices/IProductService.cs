using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDTO>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDTO createProductDto);
        Task UpdateProductAsync(UpdateProductDTO updateProductDto);
        Task DeleteProductAsync(string id);
        Task<UpdateProductDTO> GetByIdProductAsync(string id);
        Task<List<ResultProductWithCategoryDTO>> GetProductsWithCategoryAsync();
        Task<List<ResultProductWithCategoryDTO>> GetProductsWithCategoryByCatetegoryIdAsync(string CategoryId);
    }
}
