using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Views;
using Services.Descriptors;

namespace Services.Services
{
    public interface IProductService
    {
        Task<List<ProductCatalogView>> GetProductCatalogViewsAsync();
        Task<List<ProductCatalogView>> GetProductCatalogViewsTopAsync(int top);
        Task AddNewProductAsync(NewProductDescriptor map);
    }
}