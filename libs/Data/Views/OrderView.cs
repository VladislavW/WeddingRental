using Core.Enums;

namespace Data.Views
{
    public class OrderView
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}