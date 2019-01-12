using System;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Descriptors;
using Services.Services;
using WeddingRental.Models.Product.From;
using WeddingRental.Models.Views.User;

namespace WeddingRental.Controllers
{
    [Route("api/[controller]")]
    public sealed class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        
        public ProductController(
            IProductService productService,
            IMapper mapper, 
            UserManager<User> userManager, IUserService userService)
        {
            _productService = productService;
            _mapper = mapper;
            _userManager = userManager;
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<JsonResult> Get()
        {
            var user = await _userManager.GetUserAsync(User);
            var countryName = user == null ? string.Empty : await _userService.GetCountryNameByAsync(user.Id);
            var views = await _productService.GetProductCatalogViewsByUserCountryAsync(countryName);
            return Json(views);
        }
        
        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "admin")]
        public async Task<JsonResult> GetTop()
        {
            var views = await _productService.GetProductCatalogViewsTopAsync();
            return Json(views);
        }
        
        [HttpGet]
        [Route("[action]/{orderId}")]
        public async Task<JsonResult> GetByOrder(int orderId)
        {
            var views = await _productService.GetProductCatalogViewsByOrderAsync(orderId);
            return Json(views);
        }
        
        [HttpPut]
        [Route("[action]")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put([FromBody] NewProductModel model)
        {
            await _productService.AddNewProductAsync(_mapper.Map<NewProductDescriptor>(model));
            return Ok();
        }
    }
}