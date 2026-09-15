using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.PaymentSpecification
{
    public class PaymentByDateRangeAndStatus:BaseSpecification<Payment>
    {
        public PaymentByDateRangeAndStatus(DateTime? From, DateTime? To, PaymentStatus? paymentStatus)
        {
            AddCriteria(p =>
   (!From.HasValue || p.PaymentDate>From) &&
   (!To.HasValue || p.PaymentDate<=To) &&
   (!paymentStatus.HasValue || p.Status == paymentStatus.Value));
        }

    }
}
