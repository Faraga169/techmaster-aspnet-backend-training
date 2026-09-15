using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Specifications
{
    public static class SpecificationEvaluator<TEntity> where TEntity:BaseEntity<int>
    {
        public static IQueryable<TEntity> GetQuery( IQueryable<TEntity> inputQuery,ISpecification<TEntity> specification)
        {
            var query = inputQuery;

            if (specification.Criteria is not null)
            {
                query = query.Where(specification.Criteria);
            }

            foreach (var include in specification.Includes)
            {
                query = query.Include(include);
            }

            if (specification.OrderBy is not null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDescending is not null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            return query;
        }
    }
}
