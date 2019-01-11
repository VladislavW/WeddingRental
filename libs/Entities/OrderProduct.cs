using Core.Base;

namespace Entities
{
    public class OrderProduct : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        
        public Order Order { get; set; }
        public Product Product { get; set; }

        public static OrderProduct AddProductToOrder(Product product, Order order)
        {
            return new OrderProduct
            {
                Order = order,
                Product = product
            };
        }
    }
}