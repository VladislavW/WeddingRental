using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Persistence
{
    public sealed class UnitOfWork : IUnitOfWork 
    {
        private readonly WeddingRentalDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(
            IServiceProvider serviceProvider,
            WeddingRentalDbContext context)
        {
            _serviceProvider = serviceProvider;
            _context = context;
        }
        
        private TRepository CreateRepository<TRepository>() where TRepository : class
        {
            return _serviceProvider.GetService<TRepository>();
        }
        
        private IUserRepository _userRepository;
        private IOrderRepository _orderRepository;
        private ITerritoryRepository _territoryRepository;
        private IProductRepository _productRepository;

        public IUserRepository UserRepository =>
            _userRepository ?? (_userRepository = CreateRepository<IUserRepository>());
        
        public IOrderRepository OrderRepository =>
            _orderRepository ?? (_orderRepository = CreateRepository<IOrderRepository>());
        
        public ITerritoryRepository TerritoryRepository =>
            _territoryRepository ?? (_territoryRepository = CreateRepository<ITerritoryRepository>());
        
        public IProductRepository ProductRepository =>
            _productRepository ?? (_productRepository = CreateRepository<IProductRepository>());

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<List<T>> QueryAsync<T>(string sql, object param = null)
        {
            return (await _context.Database.GetDbConnection().QueryAsync<T>(sql, param)).ToList();
        }

        public async Task<T> QueryFirstAsync<T>(string sql, object param = null)
        {
            return await _context.Database.GetDbConnection().QueryFirstAsync<T>(sql, param);
        }

        public async Task<T> StoredProcedureFirstAsync<T>(string name, object param = null)
        {
            return await _context.Database.GetDbConnection()
                .QueryFirstAsync<T>(name, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<T>> StoredProcedureAsync<T>(string name, object param = null)
        {
            return (await _context.Database.GetDbConnection()
                    .QueryAsync<T>(name, param, commandType: CommandType.StoredProcedure))
                .ToList();
        }
    }
}