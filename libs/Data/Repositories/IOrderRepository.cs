using System.Threading.Tasks;
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
    }
}