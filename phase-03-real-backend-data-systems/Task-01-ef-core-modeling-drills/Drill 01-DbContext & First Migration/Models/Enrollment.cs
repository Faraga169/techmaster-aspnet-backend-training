namespace Drill_01_DbContext___First_Migration.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public Student Student{ get; set; } = null!;

        public int TrackId{ get; set; }

        public TrainingTrack Track { get; set; } = null!;

        public Status Status { get; set; } = Status.Pending;

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        public decimal FinalGrade { get; set; }

        public PaymentSummary PaymentSummary { get; set; } = null!;


    }
}
