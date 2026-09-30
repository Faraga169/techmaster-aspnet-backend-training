using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.BLL.DTOS;
using TrainingCenter.BLL.DTOS.User;
using TrainingCenter.BLL.Services.Interface;

namespace TrainingCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController(IAuthenticationService authenticationService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<AuthResponseDTO>>> Register(RegisterDTO registerDTO) { 
        
            var result=await authenticationService.Register(registerDTO);
            return Ok(new ApiResponse<AuthResponseDTO>() { 
                Success=true,
                Message="User Register successfully",
                Data=result

            });
        
        }


        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<AuthResponseDTO>>> Login(LoginDTO loginDTO)
        {
            var result = await authenticationService.Login(loginDTO);
            return Ok(new ApiResponse<AuthResponseDTO>() {

                Success = true,
                Message = "User Login successfully",
                Data = result
            });

        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<ApiResponse<AuthResponseDTO>>> GetCurrentUser()
        {
            var result = await authenticationService.GetCurrentUser();
            return Ok(new ApiResponse<AuthResponseDTO>()
            {

                Success = true,
                Message = "Information of current user",
                Data = result
            });

        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO dto)
        {
            await authenticationService.ChangePassword(dto);

            return NoContent();
        }


        [HttpPost("refresh-token")]
        public async Task<ActionResult<AuthResponseDTO>> RefreshToken(RefreshTokenDTO refreshTokenDTO)
        {
            var result = await authenticationService.RefreshToken(refreshTokenDTO);

            return Ok(result);
        }

    }
}
