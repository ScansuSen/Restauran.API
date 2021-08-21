using Business.Abstract;
using DataAccess.Abstract;
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
    public class OrderStatesController : ControllerBase
    {
        IOrderStateService _orderstateService;

        public OrderStatesController(IOrderStateService orderstateService)
        {
            _orderstateService = orderstateService;
        }

        [HttpGet("getbyid")]

        public async Task<IActionResult> GetById(int orderstateId)
        {
            var state = await _orderstateService.GetById(orderstateId);
            return Ok(state);
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listedstates = await _orderstateService.GetAll();
            return Ok(listedstates);
        }
    }
}
