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
    public class ItemsController : ControllerBase
    {
        IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet("getbyid")]
         
        public async Task<IActionResult> GetById(int id)
        {
            var items = await _itemService.GetById(id);
            return Ok(items);
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listeditems = await _itemService.GetAll();
            return Ok(listeditems);
        }


        [HttpGet("getbyprice")]
        public async Task<IActionResult> GetByPrice(decimal min,decimal max)
        {
            var items = await _itemService.GetByUnitPrice(min,max);
            return Ok(items);
        }
        [HttpGet("getitemdetail")]

        public async Task<IActionResult> GetItemDetail()
        {
            var items = await _itemService.GetItemDetails();
            return Ok(items);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Item item)
        {
            var result = _itemService.Delete(item);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Post(Item item)
        {
            var result = _itemService.Create(item);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Put (Item item)
        {
            var result = _itemService.Update(item);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }





    }
}
