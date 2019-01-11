using Core.Base;
using Core.Enums;

namespace Entities
{
    public sealed class Product : BaseEntity
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public Color Color { get; set; }
        
        public int? OrderId { get; set; }
        public Order Order { get; set; }

        public void AddToOrder(Order order)
        {
            Order = order;
        }
    }
}