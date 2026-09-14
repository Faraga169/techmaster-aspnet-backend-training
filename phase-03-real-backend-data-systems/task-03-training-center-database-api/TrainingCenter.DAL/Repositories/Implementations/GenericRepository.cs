using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingCenter.DAL.Persistent;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.DAL.Repositories.Implementations
{
    public class GenericRepository<TEntity>(AppDbContext dbContext) : IGenericRepository<TEntity> where TEntity:BaseEntity<int>
    {

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var Entities = await dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
            return Entities;
        }


        public async Task<TEntity?> GetById(int id)
        {
            var entity = await dbContext.Set<TEntity>().FindAsync(id);
            return entity;
        }


        public async Task<int> Create(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }


        public async Task<int> Update(TEntity entity)
        {
            dbContext.Update(entity);
            return await dbContext.SaveChangesAsync();
        }


        public async Task<bool> Delete(int id)
        {
            var entity = await dbContext.Set<TEntity>().FindAsync(id);
            if (entity is null)
                return false;

            entity.IsDeleted = true;
            await dbContext.SaveChangesAsync();
            return true;
        }

        

      

       
    }
}
