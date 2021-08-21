using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public  class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity,new()
        where TContext : DbContext,new()
    {
        public async Task<TEntity> Create(TEntity entity) 
        {
            using (var TContext  = new TContext())
              {
                    var addedEntity =  TContext.Entry(entity);
                  addedEntity.State = EntityState.Added;
                  await TContext.SaveChangesAsync();
                  return entity;


              }
            
        }
        public async Task<TEntity> Update(TEntity entity)
        {
            using (var TContext = new TContext())
            {
                var updatedEntity = TContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await TContext.SaveChangesAsync();
                return entity;

            }
        }
        public async Task Delete(TEntity entity)
        {
            using (var TContext=new TContext())
            {
                var deletedEntity = TContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await TContext.SaveChangesAsync();

            }
        }

        public async  Task <TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var TContext=new TContext())
            {
               
              
               return  TContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }
       

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using ( var TContext=new TContext())
            {
                return filter == null
                ? await TContext.Set<TEntity>().ToListAsync()
                : await TContext.Set<TEntity>().Where(filter).ToListAsync();

            }
        }

       

      
    }
}
