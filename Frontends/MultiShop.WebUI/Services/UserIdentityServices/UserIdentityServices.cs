using MultiShop.DTOLayer.IdentityDTOs.UserDTOs;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.Services.UserIdentityServices
{
    public class UserIdentityServices : IUserIdentityService
    {
        private readonly HttpClient _httpClient;

        public UserIdentityServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultUserDTO>> GetAllUserListAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5001/api/users/GetAllUserList");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultUserDTO>>(jsonData);
            return values;
        }
    }
}
