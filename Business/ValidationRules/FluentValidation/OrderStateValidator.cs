using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
   public class OrderStateValidator : AbstractValidator<OrderState>
    {
        public OrderStateValidator()
        {
            RuleFor(o => o.StateId).NotEmpty();
            RuleFor(o => o.StateName).NotEmpty();
           
        }
    }
}
