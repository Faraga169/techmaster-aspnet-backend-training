using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.DTOS.Instructor
{
    public class InstructorDTO
    {
        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool IsActive { get; set; }

        public string Specialization { get; set; } = null!;
    }
}
