using Core;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Task<List<Order>> GetAll();

        IResult Create(Order order);
        IResult Delete(Order order);
        Task<Order> GetById(int orderId);
        IResult Update(Order order);

       
    }
}