using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApiUI.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MultiShop.RapidApiUI.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> WeatherDetail()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weather-api167.p.rapidapi.com/api/weather/current?place=Izmir&units=metric&lang=en&mode=json"),
                Headers =
    {
        { "x-rapidapi-key", "59da85055bmshdb0ee20395bbf7cp129fedjsnc26e8d8bf355" },
        { "x-rapidapi-host", "weather-api167.p.rapidapi.com" },
        { "Accept", "application/json" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values =JsonConvert.DeserializeObject<WeatherViewModel.Rootobject>(body);
                ViewBag.cityTemp = values.main.temprature;
                return View(values);
            }
           
        }


    }
}
