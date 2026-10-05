using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecurityRefactoringEF.BLL.Common;
using SecurityRefactoringEF.BLL.DTOS.User;
using SecurityRefactoringEF.BLL.Services.Interface;

namespace SecurityRefactoringEF.Controllers
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

       

    }
}
