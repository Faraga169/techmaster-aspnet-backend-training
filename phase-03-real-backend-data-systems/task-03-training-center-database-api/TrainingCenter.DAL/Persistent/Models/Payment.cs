using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.presistent.Models;

namespace TrainingCenter.DAL.Persistent.Models
{
    public class Payment:BaseEntity<int>
    {
        //        PaymentId PK
        //EnrollmentId FK
        //Amount decimal
        //PaymentMethod
        //PaymentDate
        //PaymentStatus
        //ReferenceNumber
        //Notes optional

        public decimal Amount { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        public PaymentStatus Status{ get; set; }


        public Guid ReferenceNumber { get; set; } = Guid.NewGuid();

        public string? Notes { get; set; }

        public Enrollment? Enrollment { get; set; }

        public int EnrollId { get; set; }
    }
}
