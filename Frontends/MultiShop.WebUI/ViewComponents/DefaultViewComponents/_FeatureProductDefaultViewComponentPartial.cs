using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductDefaultViewComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        public _FeatureProductDefaultViewComponentPartial(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }
    }
}
