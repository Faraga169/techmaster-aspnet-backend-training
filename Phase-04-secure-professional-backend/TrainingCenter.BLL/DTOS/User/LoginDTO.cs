using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.BLL.DTOS.User
{
    public class LoginDTO
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
