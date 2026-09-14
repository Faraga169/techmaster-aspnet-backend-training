using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TrainingCenter.DAL.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        //        GET /api/payments Return payments with date range and status filter.
        //POST / api / payments Create payment for enrollment.
        //GET /api/enrollments/{id
        //    }/payments Return payment history for enrollment.
        //PUT /api/payments/{id
        //}/ status Update payment status.
        Task<IEnumerable<Payment>> GetAll(DateTime? from,DateTime? to,PaymentStatus? paymentStatus);

        Task<IEnumerable<Payment>> GetPaymentsByEnrollmentId(int enrollmentId);

        public Task<int> Create(Payment payment);

        public Task<int> Update(Payment payment);





    }
}
