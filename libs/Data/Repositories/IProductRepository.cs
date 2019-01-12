using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Enums;
using Data.Persistence;
using Data.Views;
using Entities;

namespace Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<ProductCatalogView>> GetProductCatalogViewsAsync();
        Task<List<ProductCatalogView>> GetProductCatalogViewsByOrderAsync(int orderId);
        Task AddNewProductAsync(Product newProduct);
        Task<Product> GetProductAsync(int productId);
        Task<List<ProductCatalogView>> GetProductCatalogViewsTopAsync();
        Task<List<ProductCatalogView>> GetProductCatalogViewsWithoutTypeAndColorAsync(ProductType flowers, Color white);
    }
}