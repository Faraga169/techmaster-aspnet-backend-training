using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.BLL.DTOS.User
{
    public class RegisterDTO
    {
        [Required(ErrorMessage ="Full Name is Required")]
        public string FullName { get; set; } = null!;

        [EmailAddress]
        [Required(ErrorMessage ="Email is Required")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
