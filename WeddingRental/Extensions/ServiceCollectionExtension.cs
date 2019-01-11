using System;
using System.Collections.Generic;
using System.Linq;
using Data.Persistence;
using Data.Repositories;
using Data.Repositories.Impl;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Services.Services;
using Services.Services.impl;

namespace WeddingRental.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDataInfrastructure(this IServiceCollection service, string dbConnectionString)
        {
            service.AddDbContext<WeddingRentalDbContext>(options => options
                    .UseSqlServer(dbConnectionString, sqlOptions => sqlOptions
                        .EnableRetryOnFailure()
                        .MigrationsAssembly("Data"))
                    .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning)));
                
            service.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<WeddingRentalDbContext>()
                .AddDefaultTokenProviders();
            
            service.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
        
        public static void AddServices(this IServiceCollection services)
        {
            services.TryAdd(ServiceDescriptor.Scoped(typeof(IUserService), typeof(UserService)));
            services.TryAdd(ServiceDescriptor.Scoped(typeof(IProductService), typeof(ProductService)));
            services.TryAdd(ServiceDescriptor.Scoped(typeof(IOrderService), typeof(OrderService)));
        }   
        
        public static void AddRepositories(this IServiceCollection services)
        {
            services.TryAdd(ServiceDescriptor.Scoped(typeof(IRepository<>), typeof(Repository<>)));
           services.TryAdd(ServiceDescriptor.Scoped(typeof(IUserRepository), typeof(UserRepository)));
           services.TryAdd(ServiceDescriptor.Scoped(typeof(IOrderRepository), typeof(OrderRepository)));
           services.TryAdd(ServiceDescriptor.Scoped(typeof(IProductRepository), typeof(ProductRepository)));
           services.TryAdd(ServiceDescriptor.Scoped(typeof(ITerritoryRepository), typeof(TerritoryRepository)));
        }
        
        public static void AddUnitOfWorks(this IServiceCollection services)
        {
            services.TryAdd(ServiceDescriptor.Scoped(typeof(IUnitOfWork), typeof(UnitOfWork)));
        }
    }
}