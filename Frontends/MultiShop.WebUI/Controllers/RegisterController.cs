using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.IdentityDTOs.RegisterDTOs;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public RegisterController(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDTO createRegisterDTO)
        {
            if (createRegisterDTO.Password == createRegisterDTO.ConfirmPassword)
            {
                var client = _httpclientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createRegisterDTO);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5001/api/Registers", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Login");
                }
            }

            
            return View();
        }
    }
}
