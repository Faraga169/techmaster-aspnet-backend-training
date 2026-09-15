using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity<int>
    {
        public Task<IEnumerable<TEntity>> GetAll(ISpecification<TEntity>? spec=null);

        public Task<int> Count(ISpecification<TEntity> specification);

        public Task<TEntity?> GetById(ISpecification<TEntity> spec);

        public Task Create(TEntity entity);

        public Task Update(TEntity entity);

        public Task<bool> Delete(int id);
    }
}
