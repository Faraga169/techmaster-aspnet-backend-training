namespace Drill_01_DbContext___First_Migration.Models
{
    public class TrainingTrack
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int InstructorId { get; set; }

        public Instructor Instructor { get; set; } = null!;

        public ICollection<Enrollment> Enrollments { get; set; }= new List<Enrollment>();
    }
}
