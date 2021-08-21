using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Address).NotEmpty();
            RuleFor(c => c.Address).MinimumLength(10);
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.FirstName).MinimumLength(2);
            RuleFor(c => c.LastName).MinimumLength(2);
            RuleFor(c => c.PhoneNumber).NotEmpty();
            RuleFor(c => c.PhoneNumber).MinimumLength(11);
           
        }
    }
}
