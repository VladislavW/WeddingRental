using System.Linq;
using Data.Persistence;
using Entities;

namespace Data.Repositories.Impl
{
    public class OrderRepository : Repository<Order> , IOrderRepository
    {
        public OrderRepository(WeddingRentalDbContext context) : base(context)
        {
        }
    }
}