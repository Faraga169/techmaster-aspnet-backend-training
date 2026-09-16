using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.DTOS.Enrollment
{
    public class CreateEnrollDTO
    {


        [Required(ErrorMessage ="Student is Required")]
        public int? StudentId { get; set; }

        [Required(ErrorMessage ="TrainingTrack is Required")]
        public int? TrainingTrackId { get; set; }

    }
}
