using System.Threading.Tasks;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using WeddingRental.Models.Product.From;

namespace WeddingRental.Controllers
{
    [Route("api/[controller]")]
    public class OrderController: Controller
    {
        private readonly IOrderService _orderService;
        
        private readonly UserManager<User> _userManager;
        
        public OrderController(
            IOrderService orderService, 
            UserManager<User> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }
        
        [HttpGet]
        [Route("[action]")]
        public async Task<JsonResult> Get()
        {
            var user = await _userManager.GetUserAsync(User);
            var views = await _orderService.GetOrderViewsAsync(user.Id);
            return Json(views);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Put([FromBody] ProductModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            var orderId = await _orderService
                .AddProductToOrderAsync(model.ProductId, model.OrderId, user.Id);
            return Ok(orderId);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Submit([FromBody] SubmitModel model)
        {
            await _orderService.SubmitAsync(model.OrderId);
            return Ok();
        }
    }
}