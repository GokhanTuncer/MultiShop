using MultiShop.DTOLayer.CatalogDTOs.OfferDiscountDTOs;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public class OfferDiscountService :IOfferDiscountService
    {
        private readonly HttpClient _httpClient;
        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDTO createOfferDiscountDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOfferDiscountDTO>("offerdiscounts", createOfferDiscountDto);
        }
        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _httpClient.DeleteAsync("offerdiscounts?id=" + id);
        }
        public async Task<UpdateOfferDiscountDTO> GetByIdOfferDiscountAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("offerdiscounts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateOfferDiscountDTO>();
            return values;
        }
        public async Task<List<ResultOfferDiscountDTO>> GetAllOfferDiscountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("offerdiscounts");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDTO>>(jsonData);
            return values;
        }
        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDTO updateOfferDiscountDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateOfferDiscountDTO>("offerdiscounts", updateOfferDiscountDto);
        }
    }
}
