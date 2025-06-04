using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductDefaultViewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public _FeatureProductDefaultViewComponentPartial(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44312/api/Products");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
