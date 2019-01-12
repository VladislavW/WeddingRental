using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Persistence;
using Data.Repositories;
using Data.Views;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Descriptors;

namespace Services.Services.impl
{
    public class UserService : IUserService
    {
        private readonly ITerritoryRepository _territoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public UserService(IUserRepository userRepository,
            UserManager<User> userManager, 
            RoleManager<Role> roleManager, 
            ITerritoryRepository territoryRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _territoryRepository = territoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> GetUserCountAsync()
        {
            return await _userRepository.GetUserCountAsync();
        }
        
        public async Task CreateAdministratorAsync(AdminDescriptor descriptor)
        {
            var user = new User {UserName = descriptor.Email, Email = descriptor.Email};
            var role = new Role {Name = "admin"};

            await _userManager.CreateAsync(user, descriptor.Password);
            await _roleManager.CreateAsync(role);
            await _userManager.AddToRoleAsync(user, "admin");
        }

        public Task<List<TerritoryView>> GetTerritoriesAsync()
        {
           return _territoryRepository.GetAllAsync();
        }

        public async Task UpdateTerritoryAsync(User user, int? territoryId)
        {
            if (territoryId == null)
            {
                return;
            }
            var territory = await _unitOfWork.TerritoryRepository
                .Source.FirstOrDefaultAsync(i => i.Id == territoryId.Value);
            
            user.Territory = territory;
            user.TerritoryId = territoryId;
            await _unitOfWork.CompleteAsync();
        }

        public Task<string> GetCountryNameByAsync(int userId)
        {
            return _userRepository.GetCountryNameByAsync(userId);
        }
    }
}