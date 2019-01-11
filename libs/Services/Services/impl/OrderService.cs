using System.Security.Claims;
using System.Threading.Tasks;
using Data.Repositories;
using Data.Views;
using Entities;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Services.Services.impl
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        
        public OrderService(
            IOrderRepository orderRepository, 
            IProductRepository productRepository,
            UserManager<User> userManager)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<OrderView> GetOrderViewsAsync(int userId)
        {
            return await _orderRepository.GetOrderViewsAsync(userId);
        }

        public async Task<int?> AddProductToOrderAsync(int productId, int? orderId, int userId)
        {
            var product = await _productRepository.GetProductAsync(productId);
            if (product == null)
            {
                return null;
            }
            
            var order = await _orderRepository.GetOrderAsync(orderId) ?? Order.CreateNewEmptyByUser(userId);

            product.AddToOrder(order);
            
            await _orderRepository.CompleteAsync();

            return order.Id;
        }

        public async Task SubmitAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderAsync(orderId);
            if (order == null)
            {
                return;
            }

            order.Submit();
            await _orderRepository.CompleteAsync();
        }
    }
}