using System;
using System.Linq;
using System.Reflection;
using Data.Mapping;
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

            base.OnModelCreating(builder);


            builder.Entity<User>(new UserMap().Configure);
            builder.Entity<Role>(new RoleMap().Configure);

            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaim");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRole");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogin");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserToken");


        }
    }
}