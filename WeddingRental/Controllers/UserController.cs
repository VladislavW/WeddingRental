using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

            var user = _mapper.Map<User>(model);
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
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
        [Route("[action]")]
        public async Task<IActionResult> SuccessSignIn()
        {
            //var isContactExist = await _userService.IsContactExistAsync(User.GetUserId());
            //new LoginModel(isContactExist)
            return Ok();
        }
        
        [HttpPost]
        [Route("[action]")]
        public async void SignOut()
        {
            await _signInManager.SignOutAsync();
        }
        
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<ClaimViewModel> Claims()
        {
            return User.Claims.Select(item => _mapper.Map<ClaimViewModel>(item));
        }

    }
}