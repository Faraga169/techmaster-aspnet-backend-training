using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.BLL.DTOS.Instructor
{
    public class InstructorDetailsDTO
    {
        
        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool IsActive { get; set; }

        public string Specialization { get; set; } = null!;

        public string? Bio { get; set; }
    }
}
