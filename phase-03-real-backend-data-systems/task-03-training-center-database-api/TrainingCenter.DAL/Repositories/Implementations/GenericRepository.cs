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
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.DAL.Repositories.Implementations
{
    public class GenericRepository<TEntity>(AppDbContext dbContext) : IGenericRepository<TEntity> where TEntity:BaseEntity<int>
    {

        public async Task<IEnumerable<TEntity>> GetAll(ISpecification<TEntity> spec)
        {
            var query = dbContext.Set<TEntity>().AsNoTracking();
            query = SpecificationEvaluator<TEntity>.GetQuery(query, spec);
            return await query.ToListAsync();
        }


        public async Task<TEntity?> GetById(ISpecification<TEntity> spec)
        {
            var query = dbContext.Set<TEntity>().AsNoTracking();
            query = SpecificationEvaluator<TEntity>.GetQuery(query, spec);
            return await query.FirstOrDefaultAsync();
        }


        public async Task Create(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
        }


        public async Task Update(TEntity entity)
        {
            dbContext.Update(entity);
        }


        public async Task<bool> Delete(int id)
        {
            var entity = await dbContext.Set<TEntity>().FindAsync(id);
            if (entity is null)
                return false;

            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.UtcNow;
            return true;
        }

        

      

       
    }
}
