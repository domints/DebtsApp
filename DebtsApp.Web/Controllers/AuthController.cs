using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using DebtsApp.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DebtsApp.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IUserRepository repo;
        private readonly IJwtService jwtService;

        public AuthController(
            IUserRepository r,
            IJwtService jwtService)
        {
            repo = r;
            this.jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel userDto)
        {
            var user = await repo.VerifyPassword(userDto.Email, userDto.Password).ConfigureAwait(false);

            if (user == null)
                return Unauthorized(new FailLoginResult { Success = false });

            var tokenString = jwtService.GetToken(userDto.Email, user.Name);

            // return basic user info (without password) and token to store client side
            return Ok(new SuccessLoginResult { Token = tokenString });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel userDto)
        {
            var result = await repo.AddUser(userDto.Email, userDto.Password, userDto.FullName).ConfigureAwait(false);
            if(!result)
                return Conflict();
            
            var tokenString = jwtService.GetToken(userDto.Email, userDto.FullName);
            return Ok(new SuccessLoginResult { Token = tokenString });
        }

        [HttpDelete("logout")]
        public IActionResult Logout()
        {
            return Ok();
        }

        public class RegisterModel
        {
            public string Email { get; set; }
            public string FullName { get; set; }
            public string Password { get; set; }
        }

        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class SuccessLoginResult 
        {
            public string Token { get; set; }
        }

        public class FailLoginResult
        {
            public bool Success { get; set; }
        }
    }
}