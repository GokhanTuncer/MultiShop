using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.FeatureSliderDTOs;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;

        public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            return View(values);
        }
    }
}
