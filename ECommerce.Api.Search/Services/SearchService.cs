using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrdersService ordersService;
        private readonly IProductService productService;
        private readonly ICustomersService customersService;

        public SearchService(IOrdersService ordersService, IProductService productService,ICustomersService customersService)
        {
            this.ordersService = ordersService;
            this.productService = productService;
            this.customersService = customersService;
        }
        public async Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(int customerId)
        {
            var orderResult = await ordersService.GetOrdersAsnc(customerId);
            var productsResult = await productService.GetProductsAsync();
            var customerResult = await customersService.GetCustomerAsync(customerId);
            if (orderResult.IsSuccess)
            {
                foreach (var order in orderResult.Orders)
                {
                    foreach (var item in order.Items)
                    {
                        item.ProductName = productsResult.IsSuccess ?
                            productsResult.Products.FirstOrDefault(p => p.Id == item.ProductId).Name:
                            "Product information is not available";
                    }
                }
                var result = new
                {
                    Customer = customerResult.IsSuccess ? customerResult.Customer.Name : "The name not loaded yet" ,
                    Orders = orderResult.Orders
                };
                return (true, result);
            }
            return (false, null);
        }
    }
}
