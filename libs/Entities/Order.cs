using System;
using Core.Base;
using Core.Enums;
using Entities.Identity;

namespace Entities
{
    public sealed class Order : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        
        public string OrderNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime? CreateOnUtc { get; set; }


        public static Order CreateNewEmptyByUser(int userId)
        {
            return new Order
            {
                UserId = userId,
                OrderNumber = $"{userId}-{DateTime.Now}",
                OrderStatus = OrderStatus.New,
                CreateOnUtc = DateTime.Now
            };
        }

        public void Submit()
        {
            OrderStatus = OrderStatus.Submitted;
        }
    }
}