using Core;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public  interface ICategoryService
    {
        Task<List<Category>> GetAll();
        IResult Create(Category category);
        IResult Delete (Category category);
        Task<Category> GetById(int categoryId);
       IResult Update(Category category);
    }
}
