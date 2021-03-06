using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Views;
using Entities.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Descriptors;
using Services.Services;
using WeddingRental.Models.User.From;
using WeddingRental.Models.User.To;
using WeddingRental.Models.Views.User;

namespace WeddingRental.Controllers
{
    [Route("api/[controller]")]
    public sealed class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        
        public UserController(
            UserManager<User> userManager, 
            SignInManager<User> signInManager, 
            IMapper mapper, 
            IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok();
            }

            var userCount = await _userService.GetUserCountAsync();
            if (userCount == 0)
            {
                var admin = _mapper.Map<AdminDescriptor>(model);

                await _userService.CreateAdministratorAsync(admin);
                return Redirect("/home");
            }
            
            var user = _mapper.Map<User>(model);
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userService.UpdateTerritoryAsync(user, model.TerritoryId);
                await _signInManager.SignInAsync(user, false);
                return Ok();
            }

            return BadRequest(result.Errors);
        }
        
        [HttpPost]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> SignIn([FromBody] SignInModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok();
            }

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            var result = await _signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                false,
                false);

            if (result.Succeeded)
            {
                return RedirectToAction("SuccessSignIn", "User");
            }

            return BadRequest();
        }
        
        [HttpGet]
        [AllowAnonymous]
        [Route("[action]")]
        public JsonResult IsAuthenticated()
        {
            return Json(new {isAuthenticated = User.Identity.IsAuthenticated});
        }
        
        [HttpGet]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<List<TerritoryView>> GetTerritories()
        {
            var territories = await _userService.GetTerritoriesAsync();
            return territories;
        }

        
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> SuccessSignIn()
        {
            return Ok();
        }
        
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SuccessSignIn", "User");
        }
        
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<ClaimViewModel> Claims()
        {
            return User.Claims.Select(item => _mapper.Map<ClaimViewModel>(item));
        }

    }
}