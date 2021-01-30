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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdersAsync(int id)
        {
            var result = await orderProvider.GetOrdersAsyc(id);
            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }

    }
}
