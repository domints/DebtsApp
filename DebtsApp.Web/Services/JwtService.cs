using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DebtsApp.Web.ConfigModels;
using DebtsApp.Web.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DebtsApp.Web.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtConfig config;

        public JwtService(IOptions<JwtConfig> cfg)
        {
            config = cfg.Value;
        }

        public string GetToken(string email, string name)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(config.SecretToken);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Name, name)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}