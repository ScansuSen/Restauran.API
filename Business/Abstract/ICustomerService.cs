using Core;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICustomerService
    {

        Task<List<Customer>> GetAll();

      IResult Create(Customer customer);
     IResult Delete(Customer customer);
      
        IResult Update(Customer customer );
    }
}
