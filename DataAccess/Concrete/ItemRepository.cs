using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
   public class ItemRepository : EfEntityRepositoryBase<Item, RestDbContext>, IItem
    {
        public async Task<List<ItemDetailDto>> GetItemDetails()

        {
            using (RestDbContext context=new RestDbContext())
            {
                var result = from i in context.Item
                             join c in context.Category
                            on i.CategoryId equals c.CategoryId
                             select new ItemDetailDto { CategoryName = c.CategoryName, ItemId=i.ItemId, ItemName=i.ItemName, UnitPrice=i.UnitPrice };
                return  await result.ToListAsync();
            }
          

        }
    }
}
