using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.DTOS.Payment
{
    public class UpdatePaymentDTO
    {
        public int Id { get; set; }

        public PaymentStatus Status { get; set; }
    }
}
