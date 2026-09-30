using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.BLL.DTOS.User
{
    public class ChangePasswordDTO
    {
        [Required(ErrorMessage ="Old Password is Required")]
        public string OldPassword { get; set; } = null!;


        [Required(ErrorMessage = "New Password is Required")]
        public string NewPassword { get; set; } = null!;


        [Required(ErrorMessage = "Confirm NewPassword is Required")]
        [Compare(nameof(NewPassword),ErrorMessage ="Confirm NewPassword must be same of new password")]
        public string ConfirmNewPassword { get; set; } = null!;
    }
}
