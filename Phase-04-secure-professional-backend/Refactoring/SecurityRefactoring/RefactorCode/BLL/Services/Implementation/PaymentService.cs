using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudentManagementAPI.Exceptions;
using TrainingCenter.BLL.DTOS.Enrollment;
using TrainingCenter.BLL.DTOS.Payment;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.BLL.Specifications.EnrollmentSpecification;
using TrainingCenter.BLL.Specifications.PaymentSpecification;
using TrainingCenter.BLL.Specifications.StudentSpecifications;
using TrainingCenter.BLL.Specifications.TrackSpecification;
using TrainingCenter.DAL.Persistent.Models;
using TrainingCenter.DAL.presistent.Models;
using TrainingCenter.DAL.Repositories.Interfaces;

namespace TrainingCenter.BLL.Services.Implementation
{
    public class PaymentService(IUnitOfWork unitOfWork, IMapper mapper) : IPaymentService
    {

        public async Task<PaymentDTO> Create(CreatePaymentDTO paymentdto)
        {
            
            if(paymentdto.Amount<=0)
                throw new BusinessException("Amount must be positive", 400);
            
           

            var enrollSpec = new EnrollByIdSpecification(paymentdto.EnrollId);

            var enroll = await unitOfWork.Repository<Enrollment>().GetById(enrollSpec);

            
            if (enroll is null)
                throw new BusinessException("Enrollment not found", 404);

            var specpayment = new PaidPaymentsByEnrollmentSpecification(paymentdto.EnrollId);
            var GetAllPayments = await unitOfWork.Repository<Payment>().GetAll(specpayment);

            var paidAmount = GetAllPayments.Sum(p => p.Amount);
            var Remaining = enroll.TrainingTrack!.Price - paidAmount;

            if(paymentdto.Amount>Remaining)
                throw new BusinessException("Payment amount cannot exceed the remaining amount.",400);



            var payment = mapper.Map<Payment>(paymentdto);

            await unitOfWork.Repository<Payment>().Create(payment);

            if (payment.Status == PaymentStatus.Paid)
            {
                enroll.Status = EnrollmentStatus.Active;
            }
            await unitOfWork.CompleteChanges();
            return mapper.Map<PaymentDTO>(payment);
        }

       
        
    }
}
