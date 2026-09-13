namespace Drill_01_DbContext___First_Migration.Models
{
    public class Student
    {
        public int Id{ get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; }

        public StudentProfile StudentProfile { get; set; } = null!;


        public ICollection<Enrollment> Enrollments { get; set; }= new List<Enrollment>();
    }
}
