using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.BLL.DTOS.Instructor
{
    public class CreateInstructorDTO
    {
        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Specialization { get; set; } = null!;

        public string? Bio { get; set; }
    }
}
