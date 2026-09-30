using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.BLL.DTOS.Payment;

namespace TrainingCenter.BLL.DTOS
{
    public class UnpaidOrPartiallyPaidEnrollmentDTO
    {
        public int EnrollmentId { get; set; }
        public string StudentName { get; set; } = null!;
        public string TrackName { get; set; } = null!;

        public List<PaymentDTO> Payments { get; set; } = new List<PaymentDTO>();
    }
}
