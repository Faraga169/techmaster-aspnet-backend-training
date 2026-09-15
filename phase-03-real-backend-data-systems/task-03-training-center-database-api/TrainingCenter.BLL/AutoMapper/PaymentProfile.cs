using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TrainingCenter.BLL.DTOS.Payment;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.BLL.AutoMapper
{
    public class PaymentProfile:Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentDTO>();
            CreateMap<CreatePaymentDTO, Payment>();
            CreateMap<UpdatePaymentDTO, Payment>();
        }
    }
}
