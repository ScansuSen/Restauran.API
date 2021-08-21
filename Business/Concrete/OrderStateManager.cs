using Business.Abstract;
using Business.Constant;
using Business.ValidationRules;
using Core;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderStateManager : IOrderStateService
    {
        IOrderState _orderstate;

        public OrderStateManager(IOrderState orderstate)
        {
            _orderstate = orderstate;
        }

        public async Task<List<OrderState>> GetAll()
        {
            return await _orderstate.GetAll();
        }

        public async  Task<OrderState> GetById(int orderstateId)
        {
            return await _orderstate.Get(o => o.StateId == orderstateId);        }

        [ValidationAspect(typeof(OrderStateValidator))]
        public IResult Update(OrderState orderstate)
        {
            _orderstate.Update(orderstate);
            return new SuccessResult(Messages.Updated);
        }
    }
}
