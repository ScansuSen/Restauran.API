using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class OrderItem:IEntity
    {
       
        public int OrderItemId { get; set; }
        public int ItemId { get; set; }
        public int ItemCount { get; set; }
      
       
    }
}
