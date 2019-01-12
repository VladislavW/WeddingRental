using System.Threading.Tasks;
using Core.Enums;
using Data.Persistence;
using Data.Views;
using Entities;

namespace Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<OrderView> GetOrderViewsAsync(int userId);
        Task<Order> GetOrderByUserAsync(int userId);

        Task CompleteAsync();
        Task<Order> GetOrderAsync(int orderId);
        Task<bool> HasOrderColorAsync(Color productColor, int userId);
    }
}