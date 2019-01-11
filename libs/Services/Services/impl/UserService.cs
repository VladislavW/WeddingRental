using System.Threading.Tasks;
using Data.Repositories;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Services.Descriptors;

namespace Services.Services.impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public UserService(IUserRepository userRepository,
            UserManager<User> userManager, 
            RoleManager<Role> roleManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _roleManager = roleManager;
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
    }
}