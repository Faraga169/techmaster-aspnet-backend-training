using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.DTOS.Track
{
   

public class UpdateTrackDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 3,ErrorMessage = "Title must be between 3 and 100 characters.")]
        public string Title { get; set; } = null!;


        [Required(ErrorMessage = "Code is required.")]
        [StringLength(100, MinimumLength = 2,ErrorMessage = "Code must be between 2 and 100 characters.")]
        public string Code { get; set; } = null!;


        [Range(0.01, 1000000,ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, MinimumLength = 10,ErrorMessage = "Description must be between 10 and 500 characters.")]
        public string Description { get; set; } = null!;


        public TrackLevel Level { get; set; }


        [Range(1, 30, ErrorMessage = "The Capacity of Track must be between 1 and 30.")]
        public int Capacity { get; set; }


        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }


        public TrainingStatus Status { get; set; }


        [Range(1, int.MaxValue,ErrorMessage = "InstructorId must be greater than 0.")]
        public int InstructorId { get; set; }
    }

}

