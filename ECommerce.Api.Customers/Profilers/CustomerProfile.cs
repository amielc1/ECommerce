using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Profilers
{
    public class CustomerProfile  :AutoMapper.Profile
    { 
        public CustomerProfile()
        {
            CreateMap<DB.Custumer, Models.Customer>();
        }
    }
}
