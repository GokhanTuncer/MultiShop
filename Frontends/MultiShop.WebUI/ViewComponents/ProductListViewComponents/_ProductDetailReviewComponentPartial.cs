using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CommentDTOs;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public _ProductDetailReviewComponentPartial(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

       
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorum Yönetimi";
            ViewBag.v3 = "Yorum Listesi";
            ViewBag.v0 = "Yorum İşlemleri";

            var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7126/api/Comments/CommentListByProductId?id="+ id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDTO>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
