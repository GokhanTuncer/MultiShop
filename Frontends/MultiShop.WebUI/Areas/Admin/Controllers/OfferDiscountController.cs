using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.OfferDiscountDTOs;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class OfferDiscountController : Controller
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public OfferDiscountController(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Indirim teklifi Yönetimi";
            ViewBag.v3 = "Indirim teklifi Listesi";
            ViewBag.v0 = "Indirim teklifi İşlemleri";

            var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44312/api/OfferDiscounts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDTO>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateOfferDiscount")]
        public IActionResult CreateOfferDiscount()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Indirim teklifi Yönetimi";
            ViewBag.v3 = "Indirim teklifi Ekle";
            ViewBag.v0 = "Indirim teklifi İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDTO createOfferDiscountDTO)
        {
            var client = _httpclientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createOfferDiscountDTO);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44312/api/OfferDiscounts", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:44312/api/OfferDiscounts?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateOfferDiscount/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Indirim teklifi Yönetimi";
            ViewBag.v3 = "Indirim teklifi Güncelle";
            ViewBag.v0 = "Indirim teklifi İşlemleri";
            var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44312/api/OfferDiscounts/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateOfferDiscountDTO>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateOfferDiscount/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDTO updateOfferDiscountDTO)
        {
            var client = _httpclientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateOfferDiscountDTO);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44312/api/OfferDiscounts", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }
    }
}
