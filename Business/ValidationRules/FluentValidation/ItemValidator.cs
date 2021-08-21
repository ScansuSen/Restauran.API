using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
  public  class ItemValidator:AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(i => i.ItemName).NotEmpty();
                
            RuleFor(i => i.ItemName). MinimumLength(2);
            RuleFor(i => i.UnitPrice).NotEmpty();
            RuleFor(i => i.UnitPrice).GreaterThan(0);
            RuleFor(i => i.CategoryId).NotEmpty();
           

        }

    }
}
