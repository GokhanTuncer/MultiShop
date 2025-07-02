using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.directory1 = "Multishop";
            ViewBag.directory2 = "Ana Sayfa";
            ViewBag.directory2 = "Ürün Listesi";
            return View();
        }
    }
}
