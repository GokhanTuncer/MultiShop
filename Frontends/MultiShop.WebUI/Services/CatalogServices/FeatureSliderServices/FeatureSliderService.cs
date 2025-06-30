using MultiShop.DTOLayer.CatalogDTOs.FeatureSliderDTOs;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderService
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;
        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDTO createFeatureSliderDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureSliderDTO>("featuresliders", createFeatureSliderDto);
        }
        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync("featuresliders?id=" + id);
        }
        public async Task<UpdateFeatureSliderDTO> GetByIdFeatureSliderAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("featuresliders/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateFeatureSliderDTO>();
            return values;
        }
        public async Task<List<ResultFeatureSliderDTO>> GetAllFeatureSliderAsync()
        {
            var responseMessage = await _httpClient.GetAsync("featuresliders");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDTO>>(jsonData);
            return values;
        }
        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDTO updateFeatureSliderDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDTO>("featuresliders", updateFeatureSliderDto);
        }

        public Task FeatureSliderChageStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChageStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }
    }
}
