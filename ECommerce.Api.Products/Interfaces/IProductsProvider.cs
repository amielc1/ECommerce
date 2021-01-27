using ECommerce.Api.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Interfaces
{
    public interface IProductsProvider
    {
        public Task<(bool IsSuccess, IEnumerable<Product> Products, string ErrorMessage)> GetProductsAsyc();
        public Task<(bool IsSuccess, Product Product, string ErrorMessage)> GetProductAsyc(int id);
    }
}
