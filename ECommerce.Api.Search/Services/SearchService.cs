using ECommerce.Api.Search.Interfaces;
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

        public SearchService(IOrdersService ordersService, IProductService productService)
        {
            this.ordersService = ordersService;
            this.productService = productService;
        }
        public async Task<(bool IsSuccess, dynamic SearchResults)> SearchAsync(int customerId)
        {
            var orderResult = await ordersService.GetOrdersAsnc(customerId);
            var productsResult = await productService.GetProductsAsync();
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
                    Orders = orderResult.Orders
                };
                return (true, result);
            }
            return (false, null);
        }
    }
}
