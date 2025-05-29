using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public CategoryController(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategori Yönetimi";
            ViewBag.v3 = "Kategori Listesi";
            ViewBag.v0 = "Kategori İşlemleri";

            var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44312/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategori Yönetimi";
            ViewBag.v3 = "Kategori Ekle";
            ViewBag.v0 = "Kategori İşlemleri";
            return View();
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            var client = _httpclientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDTO);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44312/api/Categories", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }
        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44312/api/Categories/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }
    }
}
