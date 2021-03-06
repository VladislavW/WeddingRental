using System;
using System.Linq;
using System.Reflection;
using Data.Mapping;
using Entities;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public class WeddingRentalDbContext : IdentityDbContext<User, Role, int>
    {
        public WeddingRentalDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new RoleMap());
            builder.ApplyConfiguration(new TerritoryMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new OrderProductMap());

            base.OnModelCreating(builder);


            builder.Entity<User>(new UserMap().Configure);
            builder.Entity<Role>(new RoleMap().Configure);
            builder.Entity<Territory>(new TerritoryMap().Configure);
            builder.Entity<Order>(new OrderMap().Configure);
            builder.Entity<Product>(new ProductMap().Configure);
            builder.Entity<OrderProduct>(new OrderProductMap().Configure);

            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaim");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRole");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogin");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserToken");


        }
    }
}