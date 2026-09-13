namespace Drill_01_DbContext___First_Migration.Models
{
    public class Student
    {
        public int Id{ get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        public StudentProfile StudentProfile { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }= new List<Enrollment>();
    }
}
