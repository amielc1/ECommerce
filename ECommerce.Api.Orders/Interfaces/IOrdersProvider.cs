using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Interfaces
{
    public interface IOrdersProvider
    {
        public Task<(bool IsSuccess, IEnumerable<Models.Order> Orders, string ErrorMessage)> GetOrdersAsyc();
        public Task<(bool IsSuccess, Models.Order Order, string ErrorMessage)> GetOrderAsyc(int id);

    }
}
