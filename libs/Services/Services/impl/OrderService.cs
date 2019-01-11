using System.Security.Claims;
using System.Threading.Tasks;
using Data.Persistence;
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
        private readonly IUnitOfWork _unitOfWork;
        
        public OrderService(
            IOrderRepository orderRepository, 
            IProductRepository productRepository,
            UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderView> GetOrderViewsAsync(int userId)
        {
            return await _orderRepository.GetOrderViewsAsync(userId);
        }

        public async Task<int?> AddProductToOrderAsync(int productId, int userId)
        {
            var product = await _productRepository.GetProductAsync(productId);
            if (product == null)
            {
                return null;
            }

            var order = await _orderRepository.GetOrderByUserAsync(userId);
            if (order == null)
            {
                order = Order.CreateNewEmptyByUser(userId);
                _unitOfWork.OrderRepository.Add(order);
            }
            
            var orderProduct = OrderProduct.AddProductToOrder(product, order);
            _unitOfWork.OrderProductRepository.Add(orderProduct);
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