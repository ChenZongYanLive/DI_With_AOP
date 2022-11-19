using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Service;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly OrderService _orderService;

        public OrderController(ILogger<OrderController> logger, OrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _orderService.GetMyOrders());
        }
    }
}