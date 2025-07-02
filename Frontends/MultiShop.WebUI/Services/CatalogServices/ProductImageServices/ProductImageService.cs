using MultiShop.DTOLayer.CatalogDTOs.ProductImageDTOs;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;
        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateProductImageAsync(CreateProductImageDTO createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductImageDTO>("productimages", createProductImageDto);
        }
        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync("productimages?id=" + id);
        }
        public async Task<GetByIDProductImageDTO> GetByIdProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimages/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIDProductImageDTO>();
            return values;
        }
        public async Task<List<ResultProductImageDTO>> GetAllProductImageAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productimages");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductImageDTO>>(jsonData);
            return values;
        }
        public async Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductImageDTO>("productimages", updateProductImageDto);
        }

        public async Task<GetByIDProductImageDTO> GetByProductIdProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimages/ProductImagesByProductId/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIDProductImageDTO>();
            return values;
        }
    }
}
