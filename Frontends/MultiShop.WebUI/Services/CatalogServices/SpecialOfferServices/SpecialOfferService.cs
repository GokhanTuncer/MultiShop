using MultiShop.DTOLayer.CatalogDTOs.SpecialOfferDTOs;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService
    {
        private readonly HttpClient _httpClient;
        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDTO createSpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync<CreateSpecialOfferDTO>("specialoffers", createSpecialOfferDto);
        }
        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync("specialoffers?id=" + id);
        }
        public async Task<UpdateSpecialOfferDTO> GetByIdSpecialOfferAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("specialoffers/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateSpecialOfferDTO>();
            return values;
        }
        public async Task<List<ResultSpecialOfferDTO>> GetAllSpecialOfferAsync()
        {
            var responseMessage = await _httpClient.GetAsync("specialoffers");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDTO>>(jsonData);
            return values;
        }
        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDTO updateSpecialOfferDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDTO>("specialoffers", updateSpecialOfferDto);
        }
    }
}
