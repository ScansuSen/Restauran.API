using Core;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public  interface IOrderItemService
    {
        IResult Create(OrderItem orderitem);
        IResult Update(OrderItem orderitem);


    }
}
