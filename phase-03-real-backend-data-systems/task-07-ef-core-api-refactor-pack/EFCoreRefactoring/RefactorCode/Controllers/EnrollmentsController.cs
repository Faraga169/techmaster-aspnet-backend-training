using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.BLL.DTOS;
using TrainingCenter.BLL.DTOS.Enrollment;
using TrainingCenter.BLL.DTOS.Payment;
using TrainingCenter.BLL.Services.Implementation;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.DAL.Persistent.Models;

namespace EFCoreRefactoring.RefactorCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController(IEnrollmentService enrollmentService,IPaymentService paymentService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(EnrollmentStatus? status, int? trackid, int? studentid, PaymentStatus? paymentStatus,int pagenumber=1,int pagesize=5) {

            var result = await enrollmentService.GetAll(status, trackid,studentid,paymentStatus,pagenumber,pagesize);
            return Ok(new ApiResponse<PaginatedResult<EnrollmentDTO>>()
            {
                Success = true,
                Message = "Enrollments retrieved successfully!",
                Data = result
            });

        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateEnrollDTO dto)
        {
            var enrollment = await enrollmentService.Create(dto);

            return Ok(
                new ApiResponse<EnrollmentDTO>
                {
                    Success = true,
                    Message = "Create enrolled successfully.",
                    Data = enrollment
                });
        }


        [HttpPost("Pay")]
        public async Task<IActionResult> Pay(CreatePaymentDTO createPaymentDTO) {

            var payment = await paymentService.Create(createPaymentDTO);

            return Ok(
                new ApiResponse<PaymentDTO>
                {
                    Success = true,
                    Message = "Create payment successfully.",
                    Data = payment
                });

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) { 
        
            await enrollmentService.Delete(id);
            return NoContent();
        }


    }
}
