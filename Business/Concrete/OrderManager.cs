using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrder _order;

        public OrderManager(IOrder order)
        {
            _order = order;
        }
        [ValidationAspect(typeof(OrderValidator))]
        public IResult Create(Order order)
        {
           
            _order.Create(order);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Order order)
        {
            _order.Delete(order);
            return new SuccessResult(Messages.Deleted);
        }

        public async Task<List<Order>> GetAll()
        {
            return await _order.GetAll();
        }

        public Task<Order> GetById(int orderId)
        {
            return _order.Get(o => o.OrderId == orderId);        }


        [ValidationAspect(typeof(OrderValidator))]
        public IResult Update(Order order)
        {
            _order.Update(order);
            return new SuccessResult(Messages.Updated);
        }
    }
}
