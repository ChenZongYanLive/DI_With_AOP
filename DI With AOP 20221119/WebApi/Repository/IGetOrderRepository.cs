using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Repository
{
    public interface IGetOrderRepository
    {
        Task<List<Order>> GetOrders();
    }
}