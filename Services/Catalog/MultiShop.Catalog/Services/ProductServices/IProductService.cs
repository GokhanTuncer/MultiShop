using MultiShop.Catalog.DTOs.ProductDTOs;


namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDTO>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDTO createProductDTO);
        Task UpdateProductAsync(UpdateProductDTO updateProductDTO);
        Task DeleteProductAsync(string id);
        Task<GetByIDProductDTO> GetByIDProductAsync(string id);

        Task<List<ResultProductsWithCategoryDTO>> GetProductsWithCategoryAsync();
        Task<List<ResultProductsWithCategoryDTO>> GetProductsWithCategoryByCategoryIDAsync(string CategoryID);
    }
}
