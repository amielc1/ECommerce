using AutoMapper;
using ECommerce.Api.Products.DB;
using ECommerce.Api.Products.Interfaces;
using ECommerce.Api.Products.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Providers
{
    public class ProductProvider : IProductsProvider
    {
        private readonly ProductsDbContext dbContext;
        private readonly ILogger<ProductProvider> logger;
        private readonly IMapper mapper;

        public ProductProvider(ProductsDbContext dbContext,ILogger<ProductProvider> logger,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.Products.Any())
            {
                dbContext.Products.Add(new DB.Product() { Id = 1,Name =  "Keyboard",Price = 50,Inventory=100});
                dbContext.Products.Add(new DB.Product() { Id = 1, Name = "Mause", Price = 5, Inventory = 200 });
                dbContext.Products.Add(new DB.Product() { Id = 1, Name = "Monitor", Price = 100, Inventory = 50 });
                dbContext.Products.Add(new DB.Product() { Id = 1, Name = "CPU", Price = 120, Inventory = 120 });
                dbContext.SaveChanges();
            }
        }

        Task<(bool IsSuccess, IEnumerable<Models.Product>, string ErrorMessage)> IProductsProvider.GetProductsAsyc()
        {
            throw new NotImplementedException();
        }
    }
}
