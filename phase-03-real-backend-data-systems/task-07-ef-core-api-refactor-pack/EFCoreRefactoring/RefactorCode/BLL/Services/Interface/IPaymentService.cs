using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.BLL.DTOS.Payment;
using TrainingCenter.BLL.DTOS.Student;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.Services.Interface
{
    public interface IPaymentService
    {
        public Task<PaymentDTO> Create(CreatePaymentDTO payment);


    }
}
