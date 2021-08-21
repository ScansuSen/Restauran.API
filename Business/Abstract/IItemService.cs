using Core;
using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IItemService
    {
        Task<List<Item>> GetAll();
    
       IResult Create(Item item);
        IResult Delete(Item item);
        Task<Item> GetById(int itemId);
       IResult Update(Item item);
        Task<List<ItemDetailDto>> GetItemDetails();
        Task<List<Item>> GetByUnitPrice(decimal min, decimal max);
        Task<List<Item>> GetByItemName(string item);
       
    }
}
