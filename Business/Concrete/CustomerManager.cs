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
    public class CustomerManager : ICustomerService
    {
        ICustomer _customer;

        public CustomerManager(ICustomer customer)
        {
            _customer = customer;
        }

      

        public async Task<List<Customer>> GetAll()
        {
            return await _customer.GetAll();
        }


        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Create(Customer customer)
        { 
            if(customer.FirstName.Length<1 ||customer.LastName.Length<1)
            {
                return new ErrorResult(Messages.CannotAdded);
            }
            _customer.Create(customer);
            return new SuccessResult(Messages.Added);
        }

         public IResult Delete(Customer customer)
        {
            _customer.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customer.Update(customer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
