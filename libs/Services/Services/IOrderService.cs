using System.Threading.Tasks;
using Data.Views;

namespace Services.Services
{
    public interface IOrderService
    {
        Task<OrderView> GetOrderViewsAsync(int userId);
        Task<int?> AddProductToOrderAsync(int productId, int? orderId, int userId);
        Task SubmitAsync(int orderId);
    }
}