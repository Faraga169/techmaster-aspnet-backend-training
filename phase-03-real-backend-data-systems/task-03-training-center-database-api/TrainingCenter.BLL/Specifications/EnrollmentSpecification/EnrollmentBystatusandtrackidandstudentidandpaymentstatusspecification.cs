using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Specifications.EnrollmentSpecification
{
    public class EnrollmentBystatusandtrackidandstudentidandpaymentstatusspecification : BaseSpecification<Enrollment>
    {
        public EnrollmentBystatusandtrackidandstudentidandpaymentstatusspecification(EnrollmentStatus? status, int? trackid, int? studentid, PaymentStatus? paymentStatus)
        {
            AddInclude(e => e.TrainingTrack!);
            AddInclude(e => e.Student!);
            AddCriteria(e =>
            (!status.HasValue || e.Status == status.Value) &&
            (!trackid.HasValue || e.TrainingTrackId == trackid.Value) &&
            (!studentid.HasValue || e.StudentId == studentid.Value) &&
            (!paymentStatus.HasValue ||e.Payments.Any(p => p.Status == paymentStatus.Value))
        );

        }
    }

}
