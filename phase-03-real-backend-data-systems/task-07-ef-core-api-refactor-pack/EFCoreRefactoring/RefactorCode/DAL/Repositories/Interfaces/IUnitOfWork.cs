using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity<int>;

        IEnrollmentRepository EnrollmentRepository();

        IInstructorRepository InstructorRepository();

        IPaymentRepository PaymentRepository();

        IReportRepository ReportRepository();

        Task<int> CompleteChanges();
    }
}
