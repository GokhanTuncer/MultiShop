using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _NavbarUILayoutComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
          var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
    
}
