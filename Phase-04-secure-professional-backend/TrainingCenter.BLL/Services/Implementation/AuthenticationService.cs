using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using StudentManagementAPI.Exceptions;
using TrainingCenter.BLL.DTOS.User;
using TrainingCenter.BLL.Services.Interface;
using TrainingCenter.DAL.Persistent;
using TrainingCenter.DAL.Persistent.Models;


namespace TrainingCenter.BLL.Services.Implementation
{
    public class AuthenticationService(AppDbContext dbContext,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : IAuthenticationService
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

            var expiresAt = DateTime.UtcNow.AddHours(1);
            return new AuthResponseDTO()
            {

                Email = user.Email,
                FullName = user.UserName,
                Role = registerDTO.Role,
                ExpiresAt = expiresAt,
                AccessToken =await CreateJWT(user,expiresAt),
                UserId = user.Id,
               
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

            var refreshTokenEntity = new RefreshToken
            {
                Token = await GenerateRefreshToken(),
                UserId = user.Id,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };

            dbContext.RefreshTokens.Add(refreshTokenEntity);

            await dbContext.SaveChangesAsync();
            var expiresAt = DateTime.UtcNow.AddHours(1);

            return new AuthResponseDTO
            {
                Email = user.Email!,
                FullName = user.UserName!,
                Role = roles.FirstOrDefault()!,
                ExpiresAt = expiresAt,
                AccessToken = await CreateJWT(user,expiresAt),
                RefreshToken = await GenerateRefreshToken(),
                UserId = user.Id,
               
            };
        }


        public async Task<AuthResponseDTO> RefreshToken(string refreshtoken) {

            var userrefreshtoken = await dbContext.RefreshTokens.FirstOrDefaultAsync(r => r.Token == refreshtoken);
            if (userrefreshtoken is null)
                throw new BusinessException("Refresh Token is invalid", 401);

            if(userrefreshtoken.IsRevoked)
                throw new BusinessException("Refresh Token is Revoked", 401);

            if(userrefreshtoken.ExpiresAt<DateTime.UtcNow)
                throw new BusinessException("Refresh Token is expired", 401);

            var user = await userManager.FindByIdAsync(userrefreshtoken.UserId);

            if(user is null)
                throw new BusinessException("user not found", 404);

            if(!user.IsActive)
                throw new BusinessException("user is not Active", 403);

            var roles = await userManager.GetRolesAsync(user);

            var expiresAt = DateTime.UtcNow.AddHours(1);
            return new AuthResponseDTO()
            {

                Email = user.Email!,
                FullName = user.UserName!,
                Role = roles.FirstOrDefault()!,
                ExpiresAt = expiresAt,
                AccessToken = await CreateJWT(user,expiresAt),
                UserId = user.Id,
              

            };


        }

        public async Task<AuthResponseDTO> GetCurrentUser() {

            var userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(userId is null)
                throw new BusinessException("User not found.", 401);

            var user = await userManager.FindByIdAsync(userId);
            if (user is null)
                throw new BusinessException("User not found.", 404);

            var role = await userManager.GetRolesAsync(user);
            return new AuthResponseDTO
            {
                UserId = user.Id,
                Email = user.Email!,
                FullName = user.UserName!,
                Role = role.FirstOrDefault()!
            };
        }

        public async Task ChangePassword(ChangePasswordDTO changePasswordDTO) {

            var userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(userId is null)
                throw new BusinessException("User not found.", 401);

            var user = await userManager.FindByIdAsync(userId);
            if (user is null)
                throw new BusinessException("User not found.", 404);

            var userpassword = await userManager.CheckPasswordAsync(user, changePasswordDTO.OldPassword);

            if(!userpassword)
                throw new BusinessException("Password is invalid", 400);

            var updatepassword = await userManager.ChangePasswordAsync(user, changePasswordDTO.OldPassword, changePasswordDTO.NewPassword);

            if (!updatepassword.Succeeded) {

                var errors = String.Join(',', updatepassword.Errors.Select(e => e.Description));
                throw new BusinessException($"{errors}", 400);
            }

            return;

        }


        private async Task<string> GenerateRefreshToken()
        {
            var randomBytes = RandomNumberGenerator.GetBytes(64);

            return Convert.ToBase64String(randomBytes);
        }
        private async Task<string> CreateJWT(ApplicationUser User,DateTime expireAt) {

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
        expires: expireAt,
        signingCredentials: signcredentials
    );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




    }
}
