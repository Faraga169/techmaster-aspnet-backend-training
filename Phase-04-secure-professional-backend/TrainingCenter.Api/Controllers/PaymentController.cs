using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.BLL.DTOS;
using TrainingCenter.BLL.DTOS.Payment;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(IPaymentService paymentService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(DateTime? from,DateTime? to,PaymentStatus? status)
        {
            var result = await paymentService.GetAll(from, to,status);

            return Ok(new ApiResponse<IEnumerable<PaymentDTO>>
            {
                Success = true,
                Message = "Payments retrieved successfully.",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentDTO dto)
        {
            var payment = await paymentService.Create(dto);

            return CreatedAtAction(
                nameof(GetAll),
                null,
                new ApiResponse<PaymentDTO>
                {
                    Success = true,
                    Message = "Payment created successfully.",
                    Data = payment
                });
        }

       

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id,UpdatePaymentDTO dto)
        {
            dto.Id = id;

            var payment = await paymentService.Update(dto);

            return Ok(new ApiResponse<PaymentDTO>
            {
                Success = true,
                Message = "Payment status updated successfully.",
                Data = payment
            });
        }
    }
}
