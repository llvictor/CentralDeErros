using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentralDeErros.Api.ViewModel;
using CentralDeErros.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CentralDeErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryUser _repo;
        private readonly Token _token;

        public UserController(IRepositoryUser repo, IOptions<Token> token)
        {
            _repo = repo;
            _token = token?.Value;
        }

        [HttpPost("Register")]
        public async Task<bool> Register([FromBody] UserViewModel user)
        {
            return await _repo.Register(user.Name, user.Email, user.Password);
        }

        [HttpPost("Login")]
        public async Task<string> Login([FromBody] LoginViewModel login)
        {
            var iu = await _repo.Login(login.Email, login.Password);
            return GenerateToken(iu);
        }

        private string GenerateToken(IdentityUser user)
        {
            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_token.Secret);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _token.Emitter,
                Audience = _token.ValidAt,
                Expires = DateTime.UtcNow.AddHours(_token.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
