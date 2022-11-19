using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Repository
{
    public class GetOrderRepositoryWithApi : IGetOrderRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GetOrderRepositoryWithApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<Order>> GetOrders()
        {
            var orders = new List<Order>();
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.GetAsync("https://localhost:5001/Order");
            if (!httpResponseMessage.IsSuccessStatusCode) return orders;
            await using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
            orders = await JsonSerializer.DeserializeAsync<List<Order>>(contentStream);
            return orders;
        }
    }
}