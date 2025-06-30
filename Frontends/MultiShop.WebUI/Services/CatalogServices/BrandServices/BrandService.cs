using MultiShop.DTOLayer.CatalogDTOs.BrandDTOs;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;
        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateBrandAsync(CreateBrandDTO createBrandDto)
        {
            await _httpClient.PostAsJsonAsync<CreateBrandDTO>("brands", createBrandDto);
        }
        public async Task DeleteBrandAsync(string id)
        {
            await _httpClient.DeleteAsync("brands?id=" + id);
        }
        public async Task<UpdateBrandDTO> GetByIdBrandAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("brands/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateBrandDTO>();
            return values;
        }
        public async Task<List<ResultBrandDTO>> GetAllBrandAsync()
        {
            var responseMessage = await _httpClient.GetAsync("brands");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDTO>>(jsonData);
            return values;
        }
        public async Task UpdateBrandAsync(UpdateBrandDTO updateBrandDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateBrandDTO>("brands", updateBrandDto);
        }
    }
}
