using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.BrandDTOs;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public BrandController(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Marka Yönetimi";
            ViewBag.v3 = "Marka Listesi";
            ViewBag.v0 = "Marka İşlemleri";

            var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44312/api/Brands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDTO>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateBrand")]
        public IActionResult CreateBrand()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Marka Yönetimi";
            ViewBag.v3 = "Marka Ekle";
            ViewBag.v0 = "Marka İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDTO createBrandDTO)
        {
            var client = _httpclientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBrandDTO);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44312/api/Brands", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:44312/api/Brands?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateBrand/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Marka Yönetimi";
            ViewBag.v3 = "Marka Güncelle";
            ViewBag.v0 = "Marka İşlemleri";
            var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44312/api/Brands/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBrandDTO>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateBrand/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDTO updateBrandDTO)
        {
            var client = _httpclientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBrandDTO);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44312/api/Brands", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }

    }
}
