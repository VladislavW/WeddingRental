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

        public async Task<Order> GetOrderAsync(int? orderId)
        {
            if (orderId == null)
            {
                return null;
            }
            
            return await Source
                .Where(item => item.OrderStatus == OrderStatus.New)
                .FirstOrDefaultAsync(item => item.Id == orderId.Value);
        }

        public Task CompleteAsync()
        {
            return _unitOfWork.CompleteAsync();
        }
    }
}