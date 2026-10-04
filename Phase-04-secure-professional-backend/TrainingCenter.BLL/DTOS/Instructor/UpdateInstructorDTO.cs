using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.BLL.DTOS.Instructor
{
    public class UpdateInstructorDTO
    {

        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, MinimumLength = 3,ErrorMessage = "Full name must be between 3 and 100 characters.")]
        public string FullName { get; set; } = null!;


        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = null!;


        public bool IsActive { get; set; }


        [Required(ErrorMessage = "Specialization is required.")]
        [StringLength(100, MinimumLength = 2,ErrorMessage = "Specialization must be between 2 and 100 characters.")]
        public string Specialization { get; set; } = null!;


        [StringLength(500,ErrorMessage = "Bio cannot exceed 500 characters.")]
        public string? Bio { get; set; }
    }
}
