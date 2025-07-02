using MultiShop.DTOLayer.CatalogDTOs.ContactDTOs;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;
        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateContactAsync(CreateContactDTO createContactDto)
        {
            await _httpClient.PostAsJsonAsync<CreateContactDTO>("contacts", createContactDto);
        }
        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync("contacts?id=" + id);
        }
        public async Task<GetByIDContactDTO> GetByIdContactAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("contacts/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIDContactDTO>();
            return values;
        }
        public async Task<List<ResultContactDTO>> GetAllContactAsync()
        {
            var responseMessage = await _httpClient.GetAsync("contacts");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDTO>>(jsonData);
            return values;
        }
        public async Task UpdateContactAsync(UpdateContactDTO updateContactDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateContactDTO>("contacts", updateContactDto);
        }
    }
}
