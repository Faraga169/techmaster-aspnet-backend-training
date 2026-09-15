using System;
using System.Collections.Generic;
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

        public DateTime PaymentDate { get; set; }

        public PaymentStatus Status { get; set; }


        public Guid ReferenceNumber { get; set; }

        public string? Notes { get; set; }

        public int EnrollId { get; set; }
    }
}
