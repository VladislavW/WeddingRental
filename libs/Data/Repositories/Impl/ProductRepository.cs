using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Persistence;
using Data.Views;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Impl
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductRepository(WeddingRentalDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<ProductCatalogView>> GetProductCatalogViewsAsync()
        {
          return Source.Select(item => new ProductCatalogView
            {
                Type = item.Type,
                ProductId = item.Id,
                ProductName = item.Name,
                ProductColor = item.Color,
                ProductNumber = item.Number
            }).ToListAsync();
        }
        
        public Task<List<ProductCatalogView>> GetProductCatalogViewsByOrderAsync(int orderId)
        {
            return Source
                .Where(item => item.OrderId == orderId)
                .Select(item => new ProductCatalogView
                {
                    Type = item.Type,
                    ProductId = item.Id,
                    ProductName = item.Name,
                    ProductColor = item.Color,
                    ProductNumber = item.Number
                }).ToListAsync();
        }

        public async Task AddNewProductAsync(Product newProduct)
        {
            Add(newProduct);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            return await Source.FirstOrDefaultAsync(item => item.Id == productId);
        }
    }
}