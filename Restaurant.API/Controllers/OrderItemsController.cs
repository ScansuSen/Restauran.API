using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        IOrderItemService _orderitemService;

        public OrderItemsController(IOrderItemService orderitemservice)
        {
            _orderitemService = orderitemservice;
        }

        [HttpPost("add")]
        public IActionResult Post(OrderItem orderitem)
        {
            var result = _orderitemService.Create(orderitem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Put(OrderItem orderitem)
        {
            var result = _orderitemService.Update(orderitem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
