using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Repositories.Specifications;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TrainingCenter.DAL.Repositories.Interfaces
{
    public interface IPaymentRepository:IGenericRepository<Payment>
    {
        //        GET /api/payments Return payments with date range and status filter.
        //POST / api / payments Create payment for enrollment.
        //GET /api/enrollments/{id
        //    }/payments Return payment history for enrollment.
        //PUT /api/payments/{id
        //}/ status Update payment status.
        Task<IEnumerable<Payment>> GetAll(ISpecification<Payment> spec);

        Task<IEnumerable<Payment>> GetPaymentsByEnrollmentId(ISpecification<Payment> spec);


    }
}
