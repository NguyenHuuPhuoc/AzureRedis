using AzureRedis.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AzureRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders(int pageIndex = 1, int pageSize = 10)
        {
            var res = await _orderService.GetAllOrderAsync(pageIndex, pageSize);
            return Ok(res);
        }
    }
}