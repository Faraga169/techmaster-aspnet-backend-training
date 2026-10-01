using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
using TrainingCenter.DAL.Specifications;

namespace TrainingCenter.BLL.Services.Implementation
{
    public class PaymentService(IUnitOfWork unitOfWork, IMapper mapper,IHttpContextAccessor contextAccessor) : IPaymentService
    {

        public async Task<IEnumerable<PaymentDTO>> GetAll(DateTime? From, DateTime? To, PaymentStatus? paymentStatus)
        {
            if(From>To)
                throw new BusinessException("Date From must be equal or less than To",400);
            var PaymentSpecification = new PaymentByDateRangeAndStatus(From,To,paymentStatus);
            var GetAllPayments = await unitOfWork.Repository<Payment>().GetAll(PaymentSpecification);
            var PaymentsDTO = mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentDTO>>(GetAllPayments);
            return PaymentsDTO;
        }
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



            if (paidAmount + paymentdto.Amount >= enroll.TrainingTrack.Price)
            {
                enroll.Status = EnrollmentStatus.Active;
            }
            await unitOfWork.CompleteChanges();
            return mapper.Map<PaymentDTO>(payment);
        }

        public async Task<PaymentDTO> Update(UpdatePaymentDTO paymentdto)
        {
            var spec = new PaymentByIdSpecification(paymentdto.Id);

            var payment = await unitOfWork.Repository<Payment>()
                .GetById(spec);

            if (payment is null)
                throw new BusinessException("Payment not found", 404);

            if (payment.Status == PaymentStatus.Paid)
                throw new BusinessException("Paid payment cannot be updated", 400);

            payment.Status = paymentdto.Status;

            await unitOfWork.Repository<Payment>().Update(payment);

            await unitOfWork.CompleteChanges();

            if (payment.Status == PaymentStatus.Paid)
            {
                var enrollSpec = new EnrollByIdSpecification(payment.EnrollId);

                var enroll = await unitOfWork.Repository<Enrollment>()
                    .GetById(enrollSpec);

                if (enroll is null)
                    throw new BusinessException("Enrollment not found", 404);

                var paymentSpec =
                    new PaidPaymentsByEnrollmentSpecification(payment.EnrollId);

                var payments = await unitOfWork.Repository<Payment>()
                    .GetAll(paymentSpec);

                var totalPaid = payments.Sum(p => p.Amount);

                if (totalPaid >= enroll.TrainingTrack!.Price)
                {
                    enroll.Status = EnrollmentStatus.Active;
                }

                await unitOfWork.CompleteChanges();
            }

            return mapper.Map<PaymentDTO>(payment);
        }



        public async Task<IEnumerable<PaymentDTO>> GetPaymentHistory(int id)
        {
            var userId = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = contextAccessor.HttpContext.User.IsInRole("Admin");
            if (userId is null)
                throw new BusinessException("User Claims not found", 401);

            var studentspec = new EnrollByIdSpecification(id);
            var enroll=await unitOfWork.Repository<Enrollment>().GetById(studentspec);

            if (enroll is null)
                throw new BusinessException("Enrollment not found", 404);

            if (!isAdmin && enroll?.Student?.UserId != userId)
                throw new BusinessException("You are not allowed to see these payments.", 403);

            var spec = new PaymentbyEnrollIdSpecification(id);
            var GetPaymentHistory = await unitOfWork.PaymentRepository().GetPaymentsByEnrollmentId(spec);

          
            if (!GetPaymentHistory.Any())
                throw new BusinessException("No payment history found for this enrollment", 404);
            var GetPaymentHistoryDTO = mapper.Map<IEnumerable<Payment>,IEnumerable<PaymentDTO>>(GetPaymentHistory);
            return GetPaymentHistoryDTO;
        }

        public async Task<IEnumerable<PaymentDTO>> GetMyPayments()
        {
            var userId = contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId is null)
                throw new BusinessException("User Claims not found", 401);

            var studentSpec = new StudentByUserIdSpecification(userId);

            var student = await unitOfWork.Repository<Student>().GetById(studentSpec);

            if (student is null)
                throw new BusinessException("Student profile not found", 404);

            var spec = new PaymentByStudentIdSpecification(student.Id);

            var payments = await unitOfWork.PaymentRepository().GetPaymentsByStudentId(spec);

            return mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentDTO>>(payments);
        }

       
    }
}
