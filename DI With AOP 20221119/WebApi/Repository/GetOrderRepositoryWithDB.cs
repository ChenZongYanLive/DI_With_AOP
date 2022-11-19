using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Repository
{
    public class GetOrderRepositoryWithDB : IGetOrderRepository
    {
        public Task<List<Order>> GetOrders()
        {
            return Task.FromResult(new List<Order>());
        }
    }
}