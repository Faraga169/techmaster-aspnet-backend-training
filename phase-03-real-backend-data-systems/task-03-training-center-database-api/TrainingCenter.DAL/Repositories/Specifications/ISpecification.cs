using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Repositories.Specifications
{
    public interface ISpecification<TEntity> where TEntity:BaseEntity<int>
    {
        Expression<Func<TEntity, bool>>? Criteria { get; }

        List<Expression<Func<TEntity, object>>> Includes { get; }

        Expression<Func<TEntity, object>>? OrderBy { get; }

        Expression<Func<TEntity, object>>? OrderByDescending { get; }
    }
}
