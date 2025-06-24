using MultiShop.DTOLayer.IdentityDTOs.LoginDTOs;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly ClientSettings _clientSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityService(HttpClient httpClient, ClientSettings clientSettings, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _clientSettings = clientSettings;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<bool> SignIn(SignUpDTO signUpDTO)
        {
            throw new NotImplementedException();
        }
    }
}
