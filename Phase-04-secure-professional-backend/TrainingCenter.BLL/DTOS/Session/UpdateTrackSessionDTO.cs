using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.BLL.DTOS.Session
{
    public class UpdateTrackSessionDTO
    {
        [Required(ErrorMessage = "Title is Required")]
        [MaxLength(50)]
        public string Title { get; set; } = null!;


        [MaxLength(100)]
        public string? Description { get; set; } = null!;


        public string? MeetingLink { get; set; } = null!;


        [Required(ErrorMessage = "Session Date is Required")]
        public DateTime SessionDate { get; set; }
    }
}
