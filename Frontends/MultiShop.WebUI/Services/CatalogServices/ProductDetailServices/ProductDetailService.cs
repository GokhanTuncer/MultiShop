using MultiShop.DTOLayer.CatalogDTOs.ProductDetailDTOs;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;
        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDetailDTO>("productdetails", createProductDetailDto);
        }
        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync("productdetails?id=" + id);
        }
        public async Task<GetByIDProductDetailDTO> GetByIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productdetails/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIDProductDetailDTO>();
            return values;
        }
        public async Task<List<ResultProductDetailDTO>> GetAllProductDetailAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productdetails");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDetailDTO>>(jsonData);
            return values;
        }
        public async Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDetailDTO>("productdetails", updateProductDetailDto);
        }

        public async Task<GetByIDProductDetailDTO> GetByProductIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productdetails/GetProductDetailByProductId/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIDProductDetailDTO>();
            return values;
        }
    }
}
