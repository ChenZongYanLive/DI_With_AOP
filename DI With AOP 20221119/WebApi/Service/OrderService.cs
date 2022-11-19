using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Model;
using WebApi.Repository;

namespace WebApi.Service
{
    public class OrderService
    {
        private readonly IGetOrderRepository _getOrderRepository;

        public OrderService(IGetOrderRepository getOrderRepository)
        {
            _getOrderRepository = getOrderRepository;
        }

        public async Task<List<Order>> GetMyOrders()
        {
            return await _getOrderRepository.GetOrders();
        }
    }
}