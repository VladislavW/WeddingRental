using System;
using Core.Base;
using Entities.Identity;

namespace Entities
{
    public sealed class Order : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        
        public string OrderNumber { get; set; }
        public DateTime? CreateOnUtc { get; set; }
    }
}