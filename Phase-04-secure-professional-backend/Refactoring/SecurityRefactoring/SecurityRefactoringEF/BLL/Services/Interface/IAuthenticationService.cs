using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityRefactoringEF.BLL.DTOS.User;

namespace SecurityRefactoringEF.BLL.Services.Interface
{
    public interface IAuthenticationService
    {
        public Task<AuthResponseDTO> Register(RegisterDTO registerDTO);

        public Task<AuthResponseDTO> Login(LoginDTO loginDTO);

      
    }
}
