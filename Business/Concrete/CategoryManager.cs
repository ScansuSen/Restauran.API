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
    public class CategoryManager : ICategoryService
    {
        ICategory _category;

        public CategoryManager(ICategory category)
        {
            _category = category;
        }

       

        public async Task<List<Category>> GetAll()
        {
            return await _category.GetAll();
        }

        public async Task<Category> GetById(int categoryId)
        {
            return await _category.Get(c=>c.CategoryId==categoryId);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Create(Category category)
        {
            if (category.CategoryName.Length < 1 || category.CategoryName.Length > 100)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _category.Create(category);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Category category)
        {
            _category.Delete(category);
            return new SuccessResult(Messages.Deleted);
        }
        [ValidationAspect(typeof(CategoryValidator))]
       public IResult Update(Category category)
        {
            _category.Update(category);
            return new SuccessResult(Messages.Updated);
        }
    }
}
