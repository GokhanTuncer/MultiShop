using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.OrderDTOs.OrderAddressDTOs;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;

        public OrderController(IOrderAddressService orderAddressService, IUserService userService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = "Siparişler";
            ViewBag.directory3 = "Sipariş İşlemleri";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDTO createOrderAddressDTO)
        {
            var values = await _userService.GetUserInfo();
            createOrderAddressDTO.UserID = values.ID;
            createOrderAddressDTO.Description = "test";

            await _orderAddressService.CreateOrderAddressAsync(createOrderAddressDTO);
            return RedirectToAction("Index", "Payment");
        }
    }
}
