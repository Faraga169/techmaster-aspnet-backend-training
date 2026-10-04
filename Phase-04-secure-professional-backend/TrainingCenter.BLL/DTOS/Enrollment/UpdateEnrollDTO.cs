using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.DTOS.Enrollment
{
    public class UpdateEnrollDTO
    {

        [Required(ErrorMessage ="Status is Required")]
       public EnrollmentStatus Status { get; set; }

    }
}
