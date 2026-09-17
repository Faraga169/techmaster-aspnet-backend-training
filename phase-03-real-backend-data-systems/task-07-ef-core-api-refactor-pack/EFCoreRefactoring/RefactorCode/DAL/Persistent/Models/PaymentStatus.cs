using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.DAL.Persistent.Models
{
    public enum PaymentStatus
    {
    Pending=1,
    Paid,
    Failed,
    Refunded
    }
}
