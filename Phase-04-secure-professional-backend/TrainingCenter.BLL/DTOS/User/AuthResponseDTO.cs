using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.BLL.DTOS.User
{
    public class AuthResponseDTO
    {
        //        AuthResponse
        //- AccessToken
        //- ExpiresAt
        //- UserId
        //- FullName
        //- Email
        //- Role

        public string Token { get; set; } = null!;
        public DateTime ExpiresAt { get; set; }

        public string UserId { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Role { get; set; } = null!;




    }
}
