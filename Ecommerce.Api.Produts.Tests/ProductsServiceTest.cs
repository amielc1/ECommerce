using ECommerce.Api.Products.Providers;
using ECommerce.Api.Products.DB;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using ECommerce.Api.Products.Profiles;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;

namespace Ecommerce.Api.Produts.Tests
{
    public class ProductsServiceTest
    {
        [Fact]
        public async Task GetProductsReturnAllProducts()
        {

            var opstions = new DbContextOptionsBuilder<ProductsDbContext>()
                .UseInMemoryDatabase(nameof(GetProductsReturnAllProducts))
                .Options;
            var dbContext = new ProductsDbContext(opstions);
            CreateProducts(dbContext);

            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            var mapper = new Mapper(configuration);

            var productProvider = new ProductProvider(dbContext, null, mapper);

            var products = await productProvider.GetProductsAsyc();
            Assert.True(products.IsSuccess);
            Assert.True(products.Products.Any());
            Assert.Null(products.ErrorMessage);
        }

        [Fact]
        public async Task GetProductsReturnAllProductsUsingValidId()
        {

            var opstions = new DbContextOptionsBuilder<ProductsDbContext>()
                .UseInMemoryDatabase(nameof(GetProductsReturnAllProductsUsingValidId))
                .Options;
            var dbContext = new ProductsDbContext(opstions);
            CreateProducts(dbContext);

            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            var mapper = new Mapper(configuration);

            var productProvider = new ProductProvider(dbContext, null, mapper);

            var products = await productProvider.GetProductAsyc(1);
            Assert.True(products.IsSuccess);
            Assert.NotNull(products.Product);
            Assert.True(products.Product.Id == 1);
            Assert.Null(products.ErrorMessage);
        }


        [Fact]
        public async Task GetProductsReturnAllProductsUsingInValidId()
        {

            var opstions = new DbContextOptionsBuilder<ProductsDbContext>()
                .UseInMemoryDatabase(nameof(GetProductsReturnAllProductsUsingInValidId))
                .Options;
            var dbContext = new ProductsDbContext(opstions);
            CreateProducts(dbContext);

            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            var mapper = new Mapper(configuration);

            var productProvider = new ProductProvider(dbContext, null, mapper);

            var products = await productProvider.GetProductAsyc(-1);
            Assert.False(products.IsSuccess);
            Assert.Null(products.Product);
            Assert.NotNull(products.ErrorMessage);
        }

        private void CreateProducts(ProductsDbContext dbContext)
        {
            for (int i = 1; i <= 10; i++)
            {
                dbContext.Products.Add(
                    new Product()
                    {
                        Id = i,
                        Name = Guid.NewGuid().ToString(),
                        Inventory = i + 10,
                        Price = (decimal)(i * 1.1)
                    });
                dbContext.SaveChanges();
            }
        }

        // some note for dockers 
    }
}
