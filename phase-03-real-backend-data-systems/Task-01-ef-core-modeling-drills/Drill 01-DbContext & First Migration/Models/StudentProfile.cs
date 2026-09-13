using System.ComponentModel.DataAnnotations;

namespace Drill_01_DbContext___First_Migration.Models
{
    public class StudentProfile
    {

        public int Id { get; set; }

        public long NationalId{ get; set; }

        public string EmergencyPhone { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; } = null!;
    }
}
