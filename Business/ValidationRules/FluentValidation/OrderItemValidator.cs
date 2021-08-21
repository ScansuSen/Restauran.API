using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class OrderItemValidator:AbstractValidator<OrderItem>
    {
        public OrderItemValidator()
        {
            RuleFor(oi => oi.ItemCount).NotEmpty();
            RuleFor(oi => oi.ItemCount).GreaterThan(0);
            RuleFor(oi => oi.ItemId).NotEmpty();
        }
    }
}
