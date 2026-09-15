using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.PaymentSpecification
{
    public class PaymentByIdSpecification:BaseSpecification<Payment>
    {
        public PaymentByIdSpecification(int id)
        {
            AddCriteria(p => p.Id == id);
        }
    }

}
