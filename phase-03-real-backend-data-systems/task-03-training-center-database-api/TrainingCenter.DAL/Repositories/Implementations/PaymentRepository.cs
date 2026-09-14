using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingCenter.DAL.Persistent;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.DAL.Repositories.Implementations
{
    public class PaymentRepository(AppDbContext dbContext) :GenericRepository<Payment>(dbContext) ,IPaymentRepository
    {

        public async Task<IEnumerable<Payment>> GetAll(DateTime? from, DateTime? to, PaymentStatus? paymentStatus)
        {
            var query = dbContext.Payments.AsNoTracking().AsQueryable();

            if (from is not null )
                query = query.Where(p => p.PaymentDate >=from);
            if (to is not null)
                query = query.Where(p=> p.PaymentDate<= to);
            if (paymentStatus is not null)
                query = query.Where(p=>p.Status==paymentStatus.Value);
            return await query.ToListAsync();

        }

        public async Task<IEnumerable<Payment>> GetPaymentsByEnrollmentId(int enrollmentId)
        {
            var GetPaymentsByEnrollId = await dbContext.Payments.AsNoTracking().Where(p => p.EnrollId == enrollmentId).ToListAsync();
            return GetPaymentsByEnrollId;
        }

       
    }
}
