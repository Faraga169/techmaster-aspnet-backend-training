using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using StudentManagementAPI.Exceptions;
using TrainingCenter.BLL.DTOS.User;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.DAL.Persistent.Models;


namespace TrainingCenter.BLL.Services.Implementation
{
    public class AuthenticationService(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,IConfiguration configuration) : IAuthenticationService
    {

        public async Task<AuthResponseDTO> Register(RegisterDTO registerDTO)
        {
            if (registerDTO.Role == "Admin")
                throw new BusinessException("Admin registration is not allowed.",400);

            if (!await roleManager.RoleExistsAsync(registerDTO.Role))
                throw new BusinessException("Role does not exist.",400);

            var userexist=await userManager.FindByEmailAsync(registerDTO.Email);

            if (userexist is not null)
                throw new BusinessException("Email is already exist", 409);




            var user = new ApplicationUser()
            {

                Email = registerDTO.Email,
                UserName = registerDTO.FullName,
                IsActive=true
            };

          

            var createUser = await userManager.CreateAsync(user,registerDTO.Password);
            if (!createUser.Succeeded) {

                var errors = string.Join(", ",createUser.Errors.Select(e => e.Description));
                throw new BusinessException($"{errors}",400);
            }

            var addToRole = await userManager.AddToRoleAsync(user,registerDTO.Role);

            if (!addToRole.Succeeded)
            {
                var errors = string.Join(", ", addToRole.Errors.Select(e => e.Description));

                throw new BusinessException(errors, 400);
            }

            return new AuthResponseDTO()
            {

                Email = user.Email,
                FullName = user.UserName,
                Role = registerDTO.Role,
                Token =await CreateJWT(user),
                UserId = user.Id,
                ExpiresAt = DateTime.UtcNow.AddHours(1)
            };

        }


        public async Task<AuthResponseDTO> Login(LoginDTO loginDTO)
        {
            var user = await userManager.FindByEmailAsync(loginDTO.Email);

            if (user is null)
                throw new BusinessException("Invalid email or password", 401);

            if (!user.IsActive)
                throw new BusinessException("User account is inactive.", 403);

            var passwordValid = await userManager.CheckPasswordAsync(user,loginDTO.Password);

            if (!passwordValid)
                throw new BusinessException("Invalid email or password", 401);

            var roles = await userManager.GetRolesAsync(user);

            return new AuthResponseDTO
            {
                Email = user.Email!,
                FullName = user.UserName!,
                Role = roles.FirstOrDefault()!,
                Token = await CreateJWT(user),
                UserId = user.Id,
                ExpiresAt = DateTime.UtcNow.AddHours(1)
            };
        }


        private async Task<string> CreateJWT(ApplicationUser User) {

            var Claims = new List<Claim>() {

                new Claim(ClaimTypes.Email,User.Email!),
                new Claim(ClaimTypes.Name,User.UserName!),
                new Claim(ClaimTypes.NameIdentifier,User.Id)
            };

            var Roles = await userManager.GetRolesAsync(User);
            foreach (var role in Roles) {

                Claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var Secretkey = configuration.GetSection("JWT")["Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secretkey!));

            var signcredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
        issuer: configuration.GetSection("JWT")["Issuer"],
        audience: configuration.GetSection("JWT")["Audience"],
        claims: Claims,
        expires: DateTime.UtcNow.AddHours(1),
        signingCredentials: signcredentials
    );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
