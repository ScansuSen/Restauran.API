using Business.Abstract;
using Business.CCS;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class ItemManager : IItemService
    {
        IItem _item;
        ILogger _logger;
        public ItemManager(IItem item,ILogger logger)
        {
            _item = item;
            _logger = logger;
        }

        
       
       
        public async  Task<List<Item>> GetAll()
        {
            return await _item.GetAll();
        }

        public async Task<Item> GetById(int itemId)
        {
            return await _item.Get(i => i.ItemId == itemId);
        }

        public async Task<List<Item>> GetByItemName(string item)
        {
            return await _item.GetAll(i=>i.ItemName==item);
        }

        public async Task<List<Item>> GetByUnitPrice(decimal min, decimal max)
        {
           return await _item.GetAll(i=>i.UnitPrice>=min && i.UnitPrice<=max);
          
        }

        public async  Task<List<ItemDetailDto>> GetItemDetails()
        {
            return await _item.GetItemDetails();
        }

        public IResult Update(Item item)
        {
          
             _item.Update(item);
            return new SuccessResult();
        }
        [ValidationAspect(typeof(ItemValidator))]
       public IResult Create(Item item)
            
        {
          


            _item.Create(item);
            return new SuccessResult(Messages.Added);
        }

       public IResult Delete(Item item)
        {
             _item.Delete(item);
            return new SuccessResult(Messages.Deleted);
        }

      
    }
}
