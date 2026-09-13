namespace Drill_01_DbContext___First_Migration.Models
{
    public class PaymentSummary
    {
        public int Id { get; set; }

        public decimal TotalRequired { get; set; }

        public decimal TotalPaid { get; set; }

        public decimal RemainingAmount => TotalRequired - TotalPaid;

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        public Enrollment Enrollment { get; set; } = null!;

        public int EnrollmentId { get; set; }

    }
}
