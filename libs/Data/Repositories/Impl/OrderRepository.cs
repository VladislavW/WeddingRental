using System.Linq;
using System.Threading.Tasks;
using Core.Enums;
using Data.Persistence;
using Data.Views;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Impl
{
    public class OrderRepository : Repository<Order> , IOrderRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderRepository(WeddingRentalDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<OrderView> GetOrderViewsAsync(int userId)
        {
            return Source
                .Where(item => item.UserId == userId)
                .Where(item => item.OrderStatus == OrderStatus.New)
                .Select(item => new OrderView
                {
                    UserId = item.UserId,
                    OrderId = item.Id,
                    OrderNumber = item.OrderNumber,
                    OrderStatus = item.OrderStatus
                }).FirstOrDefaultAsync();
        }

        public async Task<Order> GetOrderByUserAsync(int userId)
        {
            return await Source
                .Where(item => item.UserId == userId)
                .Where(item => item.OrderStatus == OrderStatus.New)
                .FirstOrDefaultAsync();
        }

        public Task CompleteAsync()
        {
            return _unitOfWork.CompleteAsync();
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            return await Source
                .Where(item => item.Id == orderId)
                .Where(item => item.OrderStatus == OrderStatus.New)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> HasOrderColorAsync(Color productColor, int userId)
        {
            return await _unitOfWork.OrderProductRepository.Source
                .Where(item => item.Order.UserId == userId)
                .Where(item => item.Order.OrderStatus == OrderStatus.New)
                .AnyAsync(item => item.Product.Color == productColor);
        }
    }
}