using System.Collections.Generic;
using System.Threading.Tasks;
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


        public Task<List<ProductCatalogView>> GetProductCatalogViewsAsync()
        {
            return _productRepository.GetProductCatalogViewsAsync();
        }

        public Task<List<ProductCatalogView>> GetProductCatalogViewsTopAsync(int top)
        {
            throw new System.NotImplementedException();
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
                Number = map.ProductNumber
            };

            await _productRepository.AddNewProductAsync(newProduct);
        }
    }
}