using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
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
    public class OrderItemManager : IOrderItemService
    {
        IOrderItem _orderitem;

        public OrderItemManager(IOrderItem orderitem)
        {
            _orderitem = orderitem;
        }
        [ValidationAspect(typeof(OrderItemValidator))]
        public IResult Create(OrderItem orderitem)
        {
         _orderitem.Create(orderitem);
            return new SuccessResult(Messages.Added);

        }
        [ValidationAspect(typeof(OrderItemValidator))]
        public IResult Update(OrderItem orderitem)
        {
            _orderitem.Update(orderitem);
            return new SuccessResult(Messages.Updated);
        }
    }
}
