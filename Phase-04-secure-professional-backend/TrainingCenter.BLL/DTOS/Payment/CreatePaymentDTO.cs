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
        [Range(0.01, 1000000,ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }


        public PaymentMethod PaymentMethod { get; set; }


        public Guid ReferenceNumber { get; set; }


        [StringLength(500,ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string? Notes { get; set; }


        [Range(1, int.MaxValue,ErrorMessage = "EnrollmentId must be greater than 0.")]
        [Required(ErrorMessage = "Enrollment is required.")]
        public int EnrollId { get; set; }
    }
}
