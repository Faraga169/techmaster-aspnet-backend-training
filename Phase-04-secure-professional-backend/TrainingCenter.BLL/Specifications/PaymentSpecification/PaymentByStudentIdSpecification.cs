using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.PaymentSpecification
{
    public class PaymentByStudentIdSpecification:BaseSpecification<Payment>
    {
        public PaymentByStudentIdSpecification(int studentId)
        {

            AddCriteria(p => p.Enrollment.StudentId == studentId);
        }
    }
}
