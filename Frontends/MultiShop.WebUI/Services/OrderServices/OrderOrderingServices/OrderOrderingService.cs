﻿using MultiShop.DTOLayer.OrderDTOs.OrderOrderingDTOs;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public class OrderOrderingService : IOrderOrderingService
    {
        private readonly HttpClient _httpClient;
        public OrderOrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ResultOrderingByUserIDDTO>> GetOrderingByUserID(string id)
        {
            
            var responseMessage = await _httpClient.GetAsync($"orderings/GetOrderingByUserID/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOrderingByUserIDDTO>>(jsonData);
            return values;
        }
    }
}
