using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.DTOS.Payment
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public DateOnly PaymentDate { get; set; }

        public PaymentStatus Status { get; set; }


        public Guid ReferenceNumber { get; set; }

        public string? Notes { get; set; }

    }
}
