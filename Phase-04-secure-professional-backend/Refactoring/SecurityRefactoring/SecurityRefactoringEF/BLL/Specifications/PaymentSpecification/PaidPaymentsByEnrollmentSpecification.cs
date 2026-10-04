using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.PaymentSpecification
{
    public class PaidPaymentsByEnrollmentSpecification:BaseSpecification<Payment>
    {
        public PaidPaymentsByEnrollmentSpecification(int enrollid)
        {
            AddCriteria(p =>p.EnrollId==enrollid&& p.Status == PaymentStatus.Paid);


        }
    }
}
