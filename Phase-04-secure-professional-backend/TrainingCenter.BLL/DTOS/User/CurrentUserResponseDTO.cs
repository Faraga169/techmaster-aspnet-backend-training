using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.BLL.DTOS.User
{
    public class CurrentUserResponseDTO
{
        //        - UserId
        //- FullName
        //- Email
        //- Role
        //- LinkedStudentId
        //- LinkedInstructorId

        public string UserId { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Role { get; set; } = null!;

        public int? StudentId { get; set; } = null!;

        public int? InstructorId { get; set; } = null!;

    }
}
