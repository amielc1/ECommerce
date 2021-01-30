using ECommerce.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private IOrdersProvider orderProvider;

        public OrdersController(IOrdersProvider orderProvider)
        {
            this.orderProvider = orderProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var result = await orderProvider.GetOrdersAsyc();
            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderAsync(int id)
        {
            var result = await orderProvider.GetOrderAsyc(id);
            if (result.IsSuccess)
            {
                return Ok(result.Order);
            }

            return NotFound();
        }

    }
}
