using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class OrderValidator:AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.StateId).NotEmpty();
            RuleFor(o => o.CustomerId).NotEmpty();
            RuleFor(o => o.TotalPrice).NotEmpty().GreaterThan(10);
            RuleFor(o => o.OrderDate).NotEmpty();
        }
    }
}
