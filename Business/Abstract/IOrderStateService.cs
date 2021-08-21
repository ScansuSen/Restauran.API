using Core;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IOrderStateService
    {
        Task<List<OrderState>> GetAll();
       IResult Update(OrderState orderstate);
        Task<OrderState> GetById( int  orderstateId);
    }
}
