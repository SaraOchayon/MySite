using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;

using Services;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        IOrderServices orderService;

        public OrderController(IMapper mapper, IOrderServices orderService)
        {
            _mapper = mapper;
            this.orderService = orderService;
        }


        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Create([FromBody] OrderDTO orderDTO )
        {
           
            Order order = _mapper.Map<OrderDTO, Order>(orderDTO);           
              order = await orderService.GetOrders(order);
            OrderDTO newOrder= _mapper.Map<Order, OrderDTO>(order);
            return CreatedAtAction(nameof(Get), new { id = order.OrderId }, newOrder);

       
        }

        [HttpGet]
        public string Get(int id)
        {
            return "string";
        }

    }
}
