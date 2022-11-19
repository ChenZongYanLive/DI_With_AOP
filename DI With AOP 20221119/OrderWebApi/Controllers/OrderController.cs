using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderWebApi.Model;

namespace OrderWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            var orders = new List<Order>();
            const int count = 10;
            for (var i = 0; i < count; i++)
            {
                var order = new Order(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
                orders.Add(order);
            }

            return orders;
        }
    }
}