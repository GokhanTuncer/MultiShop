using MultiShop.DTOLayer.CatalogDTOs.FeatureDTOs;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;
        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateFeatureAsync(CreateFeatureDTO createFeatureDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureDTO>("features", createFeatureDto);
        }
        public async Task DeleteFeatureAsync(string id)
        {
            await _httpClient.DeleteAsync("features?id=" + id);
        }
        public async Task<UpdateFeatureDTO> GetByIdFeatureAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("features/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureDTO>();
            return values;
        }
        public async Task<List<ResultFeatureDTO>> GetAllFeatureAsync()
        {
            var responseMessage = await _httpClient.GetAsync("features");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDTO>>(jsonData);
            return values;
        }
        public async Task UpdateFeatureAsync(UpdateFeatureDTO updateFeatureDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureDTO>("features", updateFeatureDto);
        }
    }
}
