using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderRepositories orderService;

        public OrderController(IOrderRepositories orderService)
        {
            this.orderService = orderService;
        }




        // POST api/<OrderController>
        [HttpPost]

        public async Task<ActionResult<Order>> Create([FromBody] Order order)
        {

            Order newOrder = await orderService.AddOrder(order);
            return CreatedAtAction(nameof(GetType), new { id = newOrder.OrderId }, newOrder);

        }



    }
}
