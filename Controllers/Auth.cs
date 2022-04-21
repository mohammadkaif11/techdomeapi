using Api1.IReposistory;
using Api1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private readonly IUserReposistory _repsistory;
        private readonly IConfiguration _configuration;


        public Auth(IUserReposistory repository, IConfiguration configuration)
        {
            _repsistory = repository;
            _configuration = configuration;
        }
        [HttpGet("{id}")]


        [HttpPost("{UserRegister}")]
        public IActionResult RegisterUser(User user)
        {
            _repsistory.RegisterByUser(user);
            return Ok(user);
        }

        [HttpPost("AdminRegister")]
        public IActionResult RegisterAdmin(User user)
        {
            _repsistory.RegisterByAdmin(user);
            return Ok(user);
        }

        [HttpPost("Login")]
        public IActionResult Login(Login login)
        {
            User user=_repsistory.Login(login.Email,login.Password);
            if (user == null)
            {
                return BadRequest("user is not found");     
            }
            string token = CreateToken(user);
            return Ok(new {Accestoken =token});
        }

        private string CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("TokenKey"));

            List<Claim> claims = new List<Claim>
            {
                new Claim("FirstName",user.FirstName),
                 new Claim("LastName",user.LastName),
                 new Claim("IsActive",user.IsActive),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Roles)
            };



            var tokenDescriptor = new JwtSecurityToken(
                claims: claims,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return jwt;
        
    }


    }
}
