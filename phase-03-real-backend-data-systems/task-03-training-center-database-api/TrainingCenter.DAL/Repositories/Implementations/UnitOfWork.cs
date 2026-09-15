using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingCenter.DAL.Persistent;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.DAL.Repositories.Implementations
{
    public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
    {


        private readonly Dictionary<Type, object> _repositories = new();

        public IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : BaseEntity<int>
        {
            var type = typeof(TEntity);

            if (!_repositories.TryGetValue(type, out var repository))
            {
                repository = new GenericRepository<TEntity>(dbContext);

                _repositories.Add(type, repository);
            }

            return (IGenericRepository<TEntity>)repository;
        }

        public IEnrollmentRepository EnrollmentRepository()
        {
            var type = typeof(IEnrollmentRepository);

            if (!_repositories.TryGetValue(type, out var repository))
            {
                repository = new EnrollmentRepository(dbContext);

                _repositories.Add(type, repository);
            }

            return (IEnrollmentRepository)repository;
        }

        public IInstructorRepository InstructorRepository()
        {
            var type = typeof(IInstructorRepository);

            if (!_repositories.TryGetValue(type, out var repository))
            {
                repository = new InstructorRepository(dbContext);

                _repositories.Add(type, repository);
            }

            return (IInstructorRepository)repository;
        }

        public IPaymentRepository PaymentRepository()
        {
            var type = typeof(IPaymentRepository);

            if (!_repositories.TryGetValue(type, out var repository))
            {
                repository = new PaymentRepository(dbContext);

                _repositories.Add(type, repository);
            }

            return (IPaymentRepository)repository;
        }

       

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity<int>
        {
            throw new NotImplementedException();
        }

        public IReportRepository ReportRepository()
        {
            var type = typeof(IReportRepository);

            if (!_repositories.TryGetValue(type, out var repository))
            {
                repository = new ReportRepository(dbContext);
                _repositories.Add(type, repository);
            }

            return (IReportRepository)repository;
        }

        public async Task<int> CompleteChanges()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
