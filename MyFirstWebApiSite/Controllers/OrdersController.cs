using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        private readonly IMapper _mapper;
        public OrdersController(IOrderServices orderServices, IMapper mapper)
        {
            _orderServices = orderServices;
            _mapper = mapper;   
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> Get()
        {
            IEnumerable<OrdersTbl> orders = await _orderServices.GetOrdersAsync();
            IEnumerable<OrderDTO> ordersDTO = _mapper.Map<IEnumerable<OrdersTbl>,IEnumerable<OrderDTO>>(orders);
            return ordersDTO;
        }

       

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrderDTO orderdto)
        {
            try
            {
                OrdersTbl orderTbl = _mapper.Map<OrderDTO, OrdersTbl>(orderdto);
                OrdersTbl order = await _orderServices.addOrderToDB(orderTbl);
                if (order != null)
                    return CreatedAtAction(nameof(Get), new { id = order.OrderId }, orderdto);
                return BadRequest(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
    }
}
