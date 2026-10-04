using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_Core_API_Refactor_Pack.OriginalBadCode
{
    using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using TrainingCenter.DAL.Persistent;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext db;
    public AuthController(AppDbContext db) { this.db = db; }
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var user = db.Users.FirstOrDefault(x => x.Email == request.Email);
        if (user == null) return Ok("wrong email");
        if (user.PasswordHash != request.Password) return Ok("wrong password");
        var token = "fake-token-" + user.Id;
        return Ok(new { token = token, user = user });
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var user = new ApplicationUser();
        user.FullName = request.FullName;
        user.Email = request.Email;
        user.PasswordHash = request.Password;
        user.Role = request.Role;
        db.Users.Add(user);
        db.SaveChanges();
        return Ok(user);
    }
}
   }

}