using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.BLL.DTOS.User;

namespace TrainingCenter.BLL.Services.Interface
{
    public interface IAuthenticationService
    {
        public Task<AuthResponseDTO> Register(RegisterDTO registerDTO);

        public Task<AuthResponseDTO> Login(LoginDTO loginDTO);

        public Task<AuthResponseDTO> GetCurrentUser();

        public Task ChangePassword(ChangePasswordDTO changePasswordDTO);

        public Task<AuthResponseDTO> RefreshToken(string refreshtoken);
    }
}
