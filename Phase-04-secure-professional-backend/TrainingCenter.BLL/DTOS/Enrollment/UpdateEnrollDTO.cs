using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.DTOS.Enrollment
{
    public class UpdateEnrollDTO
    {
        public int Id { get; set; }
       
       public EnrollmentStatus Status { get; set; }

    }
}
