using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.DTOS.Payment
{
    public class CreatePaymentDTO
    {
        public decimal Amount { get; set; }

        public PaymentMethod PaymentMethod { get; set; }




        public Guid ReferenceNumber { get; set; }

        public string? Notes { get; set; }


        [Required(ErrorMessage ="Enrollment is Required")]
        public int EnrollId { get; set; }
    }
}
