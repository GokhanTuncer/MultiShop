using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateProductAsync(CreateProductDTO createProductDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDTO>("products", createProductDto);
        }
        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync("products?id=" + id);
        }
        public async Task<UpdateProductDTO> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("products/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateProductDTO>();
            return values;
        }
        public async Task<List<ResultProductDTO>> GetAllProductAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
            return values;
        }
        public async Task UpdateProductAsync(UpdateProductDTO updateProductDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDTO>("products", updateProductDto);
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetProductsWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDTO>>(jsonData);
            return values;
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetProductsWithCategoryByCatetegoryIdAsync(string CategoryId)
        {
            var responseMessage = await _httpClient.GetAsync($"products/ProductListWithCategoryByCategoryId/{CategoryId}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDTO>>(jsonData);
            return values;
        }
    }
}