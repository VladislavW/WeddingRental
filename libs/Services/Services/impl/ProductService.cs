using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Enums;
using Data.Repositories;
using Data.Views;
using Entities;
using Services.Descriptors;

namespace Services.Services.impl
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public Task<List<ProductCatalogView>> GetProductCatalogViewsByUserCountryAsync(string countryName)
        {
            if (countryName == "Japan")
            {
                return _productRepository
                    .GetProductCatalogViewsWithoutTypeAndColorAsync(ProductType.Flowers, Color.White);
            }

            return _productRepository.GetProductCatalogViewsAsync();
        }

        public Task<List<ProductCatalogView>> GetProductCatalogViewsTopAsync()
        {
            return _productRepository.GetProductCatalogViewsTopAsync();
        }

        public Task<List<ProductCatalogView>> GetProductCatalogViewsByOrderAsync(int orderId)
        {
            return _productRepository.GetProductCatalogViewsByOrderAsync(orderId);
        }

        public async Task AddNewProductAsync(NewProductDescriptor map)
        {
            var newProduct = new Product
            {
                Name = map.ProductName,
                Number = map.ProductNumber,
                Type = map.Type,
                Color = map.ProductColor
            };

            await _productRepository.AddNewProductAsync(newProduct);
        }
    }
}