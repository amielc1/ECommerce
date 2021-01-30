using ECommerce.Api.Customers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Interfaces
{
   public interface ICustomersProvider
    {
        public Task<(bool IsSuccess, IEnumerable<Customer> Customers, string ErrorMessage)> GetCustomersAsyc();
        public Task<(bool IsSuccess, Customer Customer, string ErrorMessage)> GetCustomerAsyc(int id);

    }
}
