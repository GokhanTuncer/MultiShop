using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        [Area("User")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
