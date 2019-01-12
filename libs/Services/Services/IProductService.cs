using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Views;
using Services.Descriptors;

namespace Services.Services
{
    public interface IProductService
    {
        Task<List<ProductCatalogView>> GetProductCatalogViewsByUserCountryAsync(string countryName);
        Task<List<ProductCatalogView>> GetProductCatalogViewsTopAsync();
        Task<List<ProductCatalogView>> GetProductCatalogViewsByOrderAsync(int orderId);
        Task AddNewProductAsync(NewProductDescriptor map);
    }
}