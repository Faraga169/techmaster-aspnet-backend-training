using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity<int>
    {
        public Task<IEnumerable<TEntity>> GetAll();

        public Task<TEntity?> GetById(int id);

        public Task<int> Create(TEntity entity);

        public Task<int> Update(TEntity entity);

        public Task<bool> Delete(int id);
    }
}
