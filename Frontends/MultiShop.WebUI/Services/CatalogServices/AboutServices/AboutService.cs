using MultiShop.DTOLayer.CatalogDTOs.AboutDTOs;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;
        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateAboutAsync(CreateAboutDTO createAboutDto)
        {
            await _httpClient.PostAsJsonAsync<CreateAboutDTO>("abouts", createAboutDto);
        }
        public async Task DeleteAboutAsync(string id)
        {
            await _httpClient.DeleteAsync("abouts?id=" + id);
        }
        public async Task<UpdateAboutDTO> GetByIdAboutAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("abouts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateAboutDTO>();
            return values;
        }
        public async Task<List<ResultAboutDTO>> GetAllAboutAsync()
        {
            var responseMessage = await _httpClient.GetAsync("abouts");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(jsonData);
            return values;
        }
        public async Task UpdateAboutAsync(UpdateAboutDTO updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateAboutDTO>("abouts", updateAboutDto);
        }
    }
}
