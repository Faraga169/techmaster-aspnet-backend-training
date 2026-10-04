using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.BLL.DTOS.Student
{
    public class UpdateStudentDTO
    {

        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, MinimumLength = 3,
         ErrorMessage = "Full name must be between 3 and 100 characters.")]
        public string FullName { get; set; } = null!;


        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = null!;


        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }


        public bool IsActive { get; set; }

    }
}
